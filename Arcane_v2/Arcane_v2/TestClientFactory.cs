using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Arcane
{
    class TestClientFactory : Base.Network.IClientFactory<TestClient>
    {
        public TestClient createClient(Socket client)
        {
            return new TestClient(client, 1, new TestMessageFactory());
        }
    }
}
