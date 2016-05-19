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

namespace Arcane.Login.Frames
{
    public class ServerSelectionFrame : AbstractFrame<ServerSelectionFrame, LoginClient, AbstractMessage>
    {
        private static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();

        public ServerSelectionFrame(LoginClient client) : base(client)
        {
        }

        public override void OnAttached()
        {
            Client.CurrentContext = ContextEnum.ServerSelection;
            GameLinkManager.Instance.OnStatusUpdated += Instance_OnStatusUpdated;
            Client.AddFrame(new PseudoSearchFrame(Client));
            Client.SendMessage(GameServerHelper.MakeServersListMessage(Client.Account));
        }

        public override void OnDettached()
        {
            GameLinkManager.Instance.OnStatusUpdated -= Instance_OnStatusUpdated;
            Client.RemoveFrame(Client.GetFrame<PseudoSearchFrame>());
        }

        private void Instance_OnStatusUpdated(GameLinkClient server, ServerStatusEnum newStatus)
        {
            Client.SendMessage(new ServerStatusUpdateMessage(GameServerHelper.MakeGameServerInformations(Client.Account, server.ServerInformations)));
        }

        [MessageHandler]
        public void ServerSelectionMessage(ServerSelectionMessage msg)
        {
            Client.SendMessage(new SelectedServerRefusedMessage(msg.serverId, ServerConnectionErrorEnum.SERVER_CONNECTION_ERROR_DUE_TO_STATUS.ToSByte(), ServerStatusEnum.OFFLINE.ToSByte()));
            Client.SendMessage(GameServerHelper.MakeServersListMessage(Client.Account));
        }
    }
}
