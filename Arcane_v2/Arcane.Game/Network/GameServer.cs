using Arcane.Protocol;
using Chuckame.IO.TCP.Client;
using Chuckame.IO.TCP.Server;
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
        class LoginClientFactory : IClientFactory<GameClient, AbstractMessage>
        {
            private static LoginClientFactory _instance = new LoginClientFactory();

            public static LoginClientFactory Instance
            {
                get
                {
                    return _instance;
                }
            }

            public GameClient createClient(Socket socket)
            {
                return new GameClient(socket);
            }
        }
        public GameServer(IPAddress host, int port, int maxConnections) : base(host, port, maxConnections, LoginClientFactory.Instance)
        {
            OnClientAccepted += GameServer_OnClientAccepted;
            OnStarted += GameServer_OnStarted;
        }

        private static void GameServer_OnStarted(GameServer obj)
        {
            Console.WriteLine("Serveur lancé !");
        }

        private static void GameServer_OnClientAccepted(GameServer me, GameClient client)
        {
            Console.WriteLine(client + " accepted !");
            //client.AddFrame(new ConnectionFrame(client));
        }
    }
}
