using Arcane.Base.Entities;
using Arcane.Base.Network.GameLink.Messages;
using Chuckame.IO.TCP.Messages;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Game.Network.GameLink.Frames
{
    public class BeforeFrame : AbstractFrame<BeforeFrame, GameLinkConnector, AbstractGameLinkMessage>
    {
        private static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();

        public BeforeFrame(GameLinkConnector client) : base(client)
        {
        }

        protected override void OnAttached()
        {
            Client.SendMessage(new HelloMessage { ServerId = Config.ServerId, Status = GameLinkConnectorManager.Instance.ServerStatus });
        }

        protected override void OnDetached()
        {
        }

        [MessageHandler]
        public void GameServerAcceptedMessage(GameServerAcceptedMessage msg)
        {
            Client.RemoveFrame(this);
            Client.AddFrame(new LinkFrame(Client));
        }
    }
}
