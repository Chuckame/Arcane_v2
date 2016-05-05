using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Arcane.Base.Network;

namespace Arcane
{
    class TestClient : Base.Network.BaseClient<TestClient>
    {
        public TestClient(Socket socket, int bufferSize, IMessageFactory messageFactory) : base(socket, bufferSize, messageFactory)
        {
        }
    }
}
