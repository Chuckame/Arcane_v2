using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Chuckame.IO.TCP.Server;
using Chuckame.IO.TCP.Client;
using Arcane.Protocol;
using System.Net.Sockets;
using Arcane.Login.Frames;
using Arcane.Login.Helpers;
using NLog;

namespace Arcane.Login.Network
{
    public class LoginServer : AbstractBaseServer<LoginServer, LoginClient, AbstractMessage>
    {
        private static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();
        public LoginServer(IPAddress host, int port, int maxConnections) : base(host, port, maxConnections, LoginClientFactory.Instance)
        {
            OnClientAccepted += LoginServer_OnClientAccepted;
            OnStarted += LoginServer_OnStarted;
        }

        private static void LoginServer_OnStarted(LoginServer obj)
        {
            LOGGER.Info("Server started !");
        }

        private static void LoginServer_OnClientAccepted(LoginServer me, LoginClient client)
        {
            LOGGER.Info("New client !");
            FrameOrchestrator.GoToConnection(client);
        }
    }
}
