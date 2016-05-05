using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Arcane.Base.Network;

namespace Arcane
{
    class TestServer : Base.Network.BaseServer<TestServer, TestClient>
    {
        public TestServer(IPAddress host, int port, int maxConnections, IClientFactory<TestClient> clientFactory) : base(host, port, maxConnections, clientFactory)
        {
        }
    }
}
