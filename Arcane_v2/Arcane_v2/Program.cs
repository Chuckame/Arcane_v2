using Arcane.Base.Network.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Arcane
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var server = new TestServer(System.Net.IPAddress.Parse("127.0.0.1"), 5555, 1000, new TestClientFactory()))
            using (var client = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp))
            {
                server.OnClientAccepted += Server_OnClientAccepted;
                server.Start();
                client.Connect("127.0.0.1", 5555);
                Thread.Sleep(1000);
                client.Send(new byte[] { 68, 69, 65, 75 });
            }
            Console.ReadLine();
        }

        private static void Server_OnClientAccepted(TestServer arg1, TestClient arg2)
        {
            Console.WriteLine("New client !");
            arg2.OnMessageReceiving += Arg2_OnMessageReceiving;
            arg2.OnMessageReceived += Arg2_OnMessageReceived;
        }

        private static void Arg2_OnMessageReceived(TestClient arg1, Base.Network.IMessage arg2)
        {
            Console.WriteLine($"RECEIVED from client : {Encoding.UTF8.GetString((arg2 as RawMessage).Bytes)} !");
        }

        private static void Arg2_OnMessageReceiving(TestClient obj)
        {
            Console.WriteLine("Receiving from client...");
        }
    }
}
