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
using Arcane.Login.Network.GameLink;
using Arcane.Base.Network.GameLink.Messages;
using Arcane.Base.Network.GameLink;
using static Arcane.Base.Network.GameLink.LinkMessageHandle;

namespace Arcane.Login.Frames
{
    public class ServerSelectionFrame : AbstractFrame<ServerSelectionFrame, LoginClient, AbstractMessage>
    {
        private static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();

        public ServerSelectionFrame(LoginClient client) : base(client)
        {
        }

        protected override void OnAttached()
        {
            Client.CurrentContext = ContextEnum.ServerSelection;
            GameLinkManager.Instance.OnStatusUpdated += Instance_OnStatusUpdated;
            Client.SendMessage(GameServerHelper.MakeServersListMessage(Client.Account));
        }

        protected override void OnDetached()
        {
            GameLinkManager.Instance.OnStatusUpdated -= Instance_OnStatusUpdated;
        }

        private void Instance_OnStatusUpdated(GameLinkClient server, ServerStatusEnum newStatus)
        {
            Client.SendMessage(new ServerStatusUpdateMessage(GameServerHelper.MakeGameServerInformations(Client.Account, server.ServerInformations)));
        }

        [MessageHandler]
        public void ServerSelectionMessage(ServerSelectionMessage msg)
        {
            if (GameLinkManager.Instance.IsServerExists((ushort)msg.serverId))
            {
                var server = GameLinkManager.Instance.GetServer((ushort)msg.serverId);
                if (server.ServerInformations.Status.IsSelectable())
                {
                    var token = Utils.RandomString(32);
                    try
                    {
                        var result = server.SendMessageAndWaitResponse<ClientIncomingTokenResultMessage>(new ClientIncomingTokenMessage { AccountId = Client.Account.Id, Ticket = token }, 3000);
                        if (result.Success)
                        {
                            Client.SendMessage(new SelectedServerDataMessage(msg.serverId, server.ServerInformations.Host, server.ServerInformations.Port, true/*GameServerHelper.CanCreateCharacter(Client.Account, msg.serverId)*/, token));
                            Client.RemoveFrame(this);
                            Client.Disconnect();
                        }
                        else
                        {
                            Client.SendMessage(new SelectedServerRefusedMessage(msg.serverId, ServerConnectionErrorEnum.SERVER_CONNECTION_ERROR_NO_REASON.ToSByte(), server.ServerInformations.Status.ToSByte()));
                        }
                    }
                    catch (HandleTimeoutException)
                    {
                        Client.SendMessage(new SelectedServerRefusedMessage(msg.serverId, ServerConnectionErrorEnum.SERVER_CONNECTION_ERROR_NO_REASON.ToSByte(), server.ServerInformations.Status.ToSByte()));
                    }
                }
                else
                {
                    Client.SendMessage(new SelectedServerRefusedMessage(msg.serverId, ServerConnectionErrorEnum.SERVER_CONNECTION_ERROR_DUE_TO_STATUS.ToSByte(), server.ServerInformations.Status.ToSByte()));
                }
            }
            else
            {
                Client.SendMessage(new SelectedServerRefusedMessage(msg.serverId, ServerConnectionErrorEnum.SERVER_CONNECTION_ERROR_DUE_TO_STATUS.ToSByte(), ServerStatusEnum.OFFLINE.ToSByte()));
            }
        }
    }
}
