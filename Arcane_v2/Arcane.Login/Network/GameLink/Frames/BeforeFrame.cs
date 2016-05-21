using Arcane.Base.Entities;
using Arcane.Base.Network.GameLink.Messages;
using Castle.ActiveRecord;
using Chuckame.IO.TCP.Messages;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Login.Network.GameLink.Frames
{
    public class BeforeFrame : AbstractFrame<BeforeFrame, GameLinkClient, AbstractGameLinkMessage>
    {
        private static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();

        public BeforeFrame(GameLinkClient client) : base(client)
        {
        }

        public override void OnAttached()
        {
        }

        public override void OnDettached()
        {
        }

        [MessageHandler]
        public void HelloMessage(HelloMessage msg)
        {
            var serverEntity = GameServerEntity.TryFind(msg.ServerId);
            if (serverEntity == null)
            {
                Client.Disconnect();
                LOGGER.Info("Received unknown/unauthorized server informations. Game server disconnected !");
            }
            else
            {
                Client.ServerInformations = serverEntity;
                var frame = new LinkFrame(Client);
                frame.StatusMessage(msg);
                Client.RemoveFrame(this);
                Client.AddFrame(frame);
            }
        }
    }
}
