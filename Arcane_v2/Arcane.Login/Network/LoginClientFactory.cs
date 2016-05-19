using Arcane.Protocol;
using Chuckame.IO.TCP.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Login.Network
{
    public class LoginClientFactory : IClientFactory<LoginClient, AbstractMessage>
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
}
