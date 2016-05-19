using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Login.Network
{
    public static class LoginServerFactory
    {
        public static LoginServer CreateLoginServer(IPAddress host, int port, int maxConnections)
        {
            return new LoginServer(host, port, maxConnections);
        }
    }
}
