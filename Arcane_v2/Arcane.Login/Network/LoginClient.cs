using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using Chuckame.IO.TCP.Client;
using Chuckame.IO.TCP.Messages;
using Arcane.Protocol;
using Arcane.Protocol.Messages;
using Arcane.Base.Entities;

namespace Arcane.Login.Network
{
    public class LoginClient : AbstractBaseClient<LoginClient, AbstractMessage>
    {
        public const int BUFFER_SIZE = 8192;
        public Account Account { get; set; }
        public bool HasAccount { get { return Account != null; } }
        public ContextEnum CurrentContext { get; set; }

        public LoginClient(Socket socket) : base(socket, BUFFER_SIZE, MessageBuilder.Instance)
        {
            this.OnMessageReceived += LoginClient_OnMessageReceived;
        }

        private void LoginClient_OnMessageReceived(LoginClient arg1, AbstractMessage arg2)
        {
            Console.WriteLine("LoginClient: msg received !");
        }
    }
}
