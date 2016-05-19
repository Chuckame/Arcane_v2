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
    public class GameLinkFrame : AbstractFrame<GameLinkFrame, GameLinkClient, IGameLinkMessage>
    {
        private static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();

        public GameLinkFrame(GameLinkClient client) : base(client)
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
            if (Client.HasServerInformations)
            {
                Client.Disconnect();
                LOGGER.Info("Received unexpected HelloMessage. Game server disconnected !");
            }
            else
            {
                var serverEntity = GameServerEntity.Find(msg.ServerId);
                if (serverEntity == null)
                {
                    Client.Disconnect();
                    LOGGER.Info("Received unknown/unauthorized server informations. Game server disconnected !");
                }
                else
                {
                    Client.ServerInformations = serverEntity;
                    StatusMessage(msg);
                }
            }
        }

        [MessageHandler]
        public void StatusMessage(StatusMessage msg)
        {
            if (!Client.HasServerInformations)
            {
                Client.Disconnect();
                LOGGER.Info("Received unexpected StatusMessage. Game server disconnected !");
            }
            else
            {
                Client.UpdateStatus(msg.Status);
            }
        }
    }
}
