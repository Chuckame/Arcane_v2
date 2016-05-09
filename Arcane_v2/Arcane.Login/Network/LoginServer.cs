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

namespace Arcane.Login.Network
{
    public class LoginServer : AbstractBaseServer<LoginServer, LoginClient, AbstractMessage>
    {
        class LoginClientFactory : IClientFactory<LoginClient, AbstractMessage>
        {
            private static LoginClientFactory _instance = new LoginClientFactory();

            public static LoginClientFactory Instance
            {
                get
                {
                    return _instance;
                }
            }

            public LoginClient createClient(Socket socket)
            {
                return new LoginClient(socket);
            }
        }
        public LoginServer(IPAddress host, int port, int maxConnections) : base(host, port, maxConnections, LoginClientFactory.Instance)
        {
            OnClientAccepted += LoginServer_OnClientAccepted;
            OnStarted += LoginServer_OnStarted;
        }

        private void LoginServer_OnStarted(LoginServer obj)
        {
            Console.WriteLine("Serveur lancé !");
        }

        private void LoginServer_OnClientAccepted(LoginServer me, LoginClient client)
        {
            Console.WriteLine(client + " accepted !");
            client.AddFrame(new ConnectionFrame(client));
        }
    }
}
