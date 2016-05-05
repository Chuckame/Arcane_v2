using Arcane.IO.TCP.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Arcane
{
    class TestClientFactory : IClientFactory<TestClient>
    {
        public TestClient createClient(Socket client)
        {
            return new TestClient(client, 3, new TestMessageFactory());
        }
    }
}
