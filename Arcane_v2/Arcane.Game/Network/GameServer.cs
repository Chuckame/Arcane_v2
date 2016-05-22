using Arcane.Game.Frames;
using Arcane.Game.Helpers;
using Arcane.Protocol;
using Chuckame.IO.TCP.Client;
using Chuckame.IO.TCP.Server;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Game.Network
{
    public class GameServer : AbstractBaseServer<GameServer, GameClient, AbstractMessage>
    {
        private static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();
        public GameServer(IPAddress host, int port, int maxConnections) : base(host, port, maxConnections, GameClientFactory.Instance)
        {
            OnClientAccepted += GameServer_OnClientAccepted;
            OnStarted += GameServer_OnStarted;
        }

        private static void GameServer_OnStarted(GameServer obj)
        {
            LOGGER.Info("Server started !");
        }

        private static void GameServer_OnClientAccepted(GameServer me, GameClient client)
        {
            LOGGER.Info($"Client accepted !");
            FrameOrchestrator.GoToApproach(client);
        }
    }
}
