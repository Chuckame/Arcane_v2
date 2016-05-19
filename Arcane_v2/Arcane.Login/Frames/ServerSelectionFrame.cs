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
            Client.AddFrame(new PseudoSearchFrame(Client));
            Client.SendMessage(GameServerHelper.MakeServersListMessage(Client.Account));
        }

        public override void OnDettached()
        {
            Client.RemoveFrame(Client.GetFrame<PseudoSearchFrame>());
        }

        [MessageHandler]
        public void ServerSelectionMessage(ServerSelectionMessage msg)
        {
            Client.SendMessage(new SelectedServerRefusedMessage(msg.serverId, ServerConnectionErrorEnum.SERVER_CONNECTION_ERROR_DUE_TO_STATUS.ToSByte(), ServerStatusEnum.OFFLINE.ToSByte()));
            Client.SendMessage(GameServerHelper.MakeServersListMessage(Client.Account));
        }
    }
}
