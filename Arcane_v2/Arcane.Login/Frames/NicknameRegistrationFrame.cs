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

namespace Arcane.Login.Frames
{
    public class NicknameRegistrationFrame : AbstractFrame<NicknameRegistrationFrame, LoginClient, AbstractMessage>
    {
        private static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();

        public NicknameRegistrationFrame(LoginClient client) : base(client)
        {
        }

        public override void OnAttached()
        {
            Client.SendMessage(new NicknameRegistrationMessage());
        }

        public override void OnDettached()
        {
        }

        [MessageHandler]
        public void NicknameChoiceRequestMessage(NicknameChoiceRequestMessage msg)
        {
            try
            {
                var newNickname = Utils.UppercaseWords(Utils.NormalizeString(msg.nickname));
                TestNickInvalid(newNickname);
                TestNickSameAsLogin(newNickname);
                TestNickTooSimilarToLogin(newNickname);
                using (new SessionScope())
                {
                    TestNickAlreadyUsed(newNickname);
                    ProcessNicknameRegistration(newNickname);
                }

            }
            catch (NickameRefusedException e)
            {
                SendRefused(e.NicknameError);
            }
            catch
            {
                SendRefused(NicknameErrorEnum.UNKNOWN_NICK_ERROR);
                throw;
            }
        }

        private void TestNickTooSimilarToLogin(string newNickname)
        {
            if (newNickname.ToUpperInvariant().Contains(Client.Account.Login.ToUpperInvariant()) || Client.Account.Login.ToUpperInvariant().Contains(newNickname.ToUpperInvariant()))
                throw new NickameRefusedException(NicknameErrorEnum.TOO_SIMILAR_TO_LOGIN);
        }

        private void TestNickSameAsLogin(string newNickname)
        {
            if (newNickname.Equals(Client.Account.Login, StringComparison.OrdinalIgnoreCase))
                throw new NickameRefusedException(NicknameErrorEnum.SAME_AS_LOGIN);
        }

        private void TestNickInvalid(string newNickname)
        {
            if (string.IsNullOrWhiteSpace(newNickname) || newNickname.Length < Config.NicknameMinLength || newNickname.Length > Config.NicknameMaxLength
                || newNickname.Any(c => !Config.NicknameAcceptedChars.Contains(c)) || Config.NicknameRefusedWords.Contains(newNickname))
                throw new NickameRefusedException(NicknameErrorEnum.INVALID_NICK);
        }

        private void TestNickAlreadyUsed(string newNickname)
        {
            if (Account.Queryable.Any(a => a.Nickname != null && newNickname.ToUpperInvariant().Equals(a.Nickname.ToUpperInvariant())))
                throw new NickameRefusedException(NicknameErrorEnum.ALREADY_USED);
        }

        private void SendRefused(NicknameErrorEnum nicknameError)
        {
            Client.SendMessage(new NicknameRefusedMessage(nicknameError.ToSByte()));
        }

        private void ProcessNicknameRegistration(string newNickname)
        {
            Client.Account.Nickname = newNickname;
            Client.Account.Update();
            Client.SendMessage(new NicknameAcceptedMessage());
            Client.SendMessage(ConnectionHelper.MakeIdentificationSuccessMessage(Client.Account, false));
            Client.RemoveFrame(this);
            FrameHelper.GoToServerSelection(Client);
        }

        [Serializable]
        private class NickameRefusedException : Exception
        {
            public NicknameErrorEnum NicknameError { get; }
            public NickameRefusedException(NicknameErrorEnum nicknameError) { NicknameError = nicknameError; }
        }
    }
}
