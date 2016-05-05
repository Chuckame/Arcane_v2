using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Arcane.Base.Network;
using Arcane.IO.TCP.Server;
using Arcane.IO.TCP.Client;

namespace Arcane
{
    class TestServer : BaseServer<TestServer, TestClient>
    {
        public TestServer(IPAddress host, int port, int maxConnections, IClientFactory<TestClient> clientFactory) : base(host, port, maxConnections, clientFactory)
        {
        }
    }
}
