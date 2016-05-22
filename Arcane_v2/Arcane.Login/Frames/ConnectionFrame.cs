using Chuckame.IO.TCP.Messages;
using Arcane.Login.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcane.Protocol;
using Arcane.Protocol.Messages;
using Arcane.Base.Tools;
using Arcane.Base.Encryption;
using NLog;
using Arcane.Protocol.Enums;
using Arcane.Base.Entities;
using Arcane.Login.Helpers;
using Castle.ActiveRecord;
using Arcane.Login.Network.GameLink;
using Arcane.Base.Common;

namespace Arcane.Login.Frames
{
    public class ConnectionFrame : AbstractFrame<ConnectionFrame, LoginClient, AbstractMessage>
    {
        private static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();
        public string Salt = Utils.RandomString(32);

        public ConnectionFrame(LoginClient client) : base(client)
        {
        }

        protected override void OnAttached()
        {
            Client.CurrentContext = ContextEnum.Connection;
            Client.SendMessage(new ProtocolRequired(CommonConfig.ProtocolRequiredVersion, CommonConfig.ProtocolCurrentVersion));
            Client.SendMessage(new HelloConnectMessage(Salt, RSAProtocol.PublicKey));
        }

        protected override void OnDetached()
        {
        }

        [MessageHandler]
        public void IdentificationMessage(IdentificationMessage msg)
        {
            try
            {
                TestVersion(msg.version);
                var account = AccountHelper.GetAccountByLogin(msg.login);
                TestAccount(account);
                TestPassword(account, msg.credentials);
                TestBanned(account);
                ProcessLogin(account, msg);
            }
            catch (IdentificationFailException e)
            {
                SendFail(e.IdentificationFailedMessage);
            }
            catch
            {
                SendFail(new IdentificationFailedMessage(IdentificationFailureReasonEnum.UNKNOWN_AUTH_ERROR.ToSByte()));
                throw;
            }
        }

        private void SendFail(IdentificationFailedMessage exMsg)
        {
            Client.SendMessage(exMsg);
            Client.Disconnect();
        }

        private void TestVersion(Protocol.Types.Version version)
        {
            if (version.major != Config.ExpectedVersion.major
                || version.minor != Config.ExpectedVersion.minor
                || version.release != Config.ExpectedVersion.release
                || version.revision != Config.ExpectedVersion.revision)
                throw new IdentificationFailException(new IdentificationFailedForBadVersionMessage(IdentificationFailureReasonEnum.BAD_VERSION.ToSByte(), Config.ExpectedVersion));
        }

        private void TestAccount(Account account)
        {
            if (account == null)
                throw new IdentificationFailException(new IdentificationFailedMessage(IdentificationFailureReasonEnum.WRONG_CREDENTIALS.ToSByte()));
        }

        private void TestPassword(Account account, sbyte[] credentials)
        {
            if (!account.Password.Equals(RSAProtocol.DecryptCredentials(credentials)))
                throw new IdentificationFailException(new IdentificationFailedMessage(IdentificationFailureReasonEnum.WRONG_CREDENTIALS.ToSByte()));
        }

        private void TestBanned(Account account)
        {
            if (account.IsBanned())
                throw new IdentificationFailException(new IdentificationFailedBannedMessage(IdentificationFailureReasonEnum.BANNED.ToSByte(), account.BannedEndDate.ToDofusTimestamp()));
        }

        private void ProcessLogin(Account account, IdentificationMessage msg)
        {
            LoginServerManager.Instance.DisconnectClientByAccount(account);
            GameLinkManager.Instance.DisconnectClientByAccount(account);
            Client.Account = account;
            account.UpdateLastConnection(Client.RemoteHost, DateTime.Now);
            Client.SendMessage(new CredentialsAcknowledgementMessage());
            Client.RemoveFrame(this);
            if (Client.Account.HasNickname())
            {
                Client.SendMessage(ConnectionHelper.MakeIdentificationSuccessMessage(account, false));
                if (msg.autoconnect && GameLinkManager.Instance.IsServerExists((ushort)msg.serverId))
                {
                    FrameOrchestrator.AutoSelectServer(Client, msg.serverId);
                }
                else
                {
                    FrameOrchestrator.GoToServerSelection(Client);
                }
            }
            else
            {
                FrameOrchestrator.GoToNicknameRegistration(Client);
            }
        }

        [Serializable]
        private class IdentificationFailException : Exception
        {
            public IdentificationFailedMessage IdentificationFailedMessage { get; }
            public IdentificationFailException(IdentificationFailedMessage msg)
            {
                IdentificationFailedMessage = msg;
            }
        }
    }
}