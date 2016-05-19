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
            Client.CurrentContext = ContextEnum.Connection;
            Client.AddFrame(new PseudoSearchFrame(Client));
            Client.SendMessage(new ServersListMessage(new[] { new Protocol.Types.GameServerInformations(1, ServerStatusEnum.ONLINE.ToSByte(), 0, false, 1, 0) }));
        }

        public override void OnDettached()
        {
            Client.RemoveFrame(Client.GetFrame<PseudoSearchFrame>());
        }

        [MessageHandler]
        public void ServerSelectionMessage(ServerSelectionMessage msg)
        {
            Client.SendMessage(new SelectedServerRefusedMessage(msg.serverId, ServerConnectionErrorEnum.SERVER_CONNECTION_ERROR_DUE_TO_STATUS.ToSByte(), ServerStatusEnum.OFFLINE.ToSByte()));
            Client.SendMessage(new ServersListMessage(new[] { new Protocol.Types.GameServerInformations(1, ServerStatusEnum.ONLINE.ToSByte(), 0, false, 1, 0) }));
        }
    }
}