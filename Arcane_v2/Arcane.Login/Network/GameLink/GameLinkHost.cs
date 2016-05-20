using Arcane.Base.Network.GameLink.Messages;
using Arcane.Login.Network.GameLink.Frames;
using Arcane.Protocol.Enums;
using Chuckame.IO.TCP.Client;
using Chuckame.IO.TCP.Messages;
using Chuckame.IO.TCP.Server;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Login.Network.GameLink
{
    public class GameLinkHost : AbstractBaseServer<GameLinkHost, GameLinkClient, AbstractGameLinkMessage>
    {
        private static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();
        public GameLinkHost(IPAddress host, int port, int maxConnections) : base(host, port, maxConnections, GameLinkClientFactory.Instance)
        {
            OnStarted += LoginServer_OnStarted;
            OnClientAccepted += LoginServer_OnClientAccepted;
        }

        private static void LoginServer_OnStarted(GameLinkHost me)
        {
            LOGGER.Info("Server started !");
        }

        private static void LoginServer_OnClientAccepted(GameLinkHost me, GameLinkClient client)
        {
            LOGGER.Debug("Client accepted !");
            client.AddFrame(new BeforeFrame(client));
        }
    }
}
