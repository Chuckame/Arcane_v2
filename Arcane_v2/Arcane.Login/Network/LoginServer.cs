using Arcane.Base.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Arcane.Login.Network
{
    public class LoginServer : BaseServer<LoginServer, LoginClient>
    {
        public LoginServer(IPAddress host, int port, int maxConnections, IClientFactory<LoginClient> clientFactory) : base(host, port, maxConnections, clientFactory)
        {
        }
    }
}
