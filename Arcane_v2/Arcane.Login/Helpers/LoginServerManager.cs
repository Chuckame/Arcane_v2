using Arcane.Base.Entities;
using Arcane.Login.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Login.Helpers
{
    public class LoginServerManager
    {
        private static LoginServerManager _instance = new LoginServerManager();

        public static LoginServerManager Instance
        {
            get
            {
                return _instance;
            }
        }

        private LoginServer server;

        private LoginServerManager()
        {
        }

        public void Initialize(IPAddress host, int port, int maxConnections)
        {
            server = new LoginServer(host, port, maxConnections);
        }

        public void Start()
        {
            if (server == null)
                throw new NullReferenceException("This instance must be initialized before.");
            server.Start();
        }
        public void Stop()
        {
            if (server == null)
                throw new NullReferenceException("This instance must be initialized before.");
            server.Stop();
        }

        public void DisconnectClientByAccount(Account account)
        {
            if (server == null)
                throw new NullReferenceException("This instance must be initialized before.");
            foreach (var client in server.Clients)
            {
                if (client.HasAccount && client.Account.Equals(account))
                    client.Disconnect();
            }
        }
    }
}
