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
using NLog;

namespace Arcane.Login.Network
{
    public class LoginClient : AbstractBaseClient<LoginClient, AbstractMessage>
    {
        private static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();
        public const int BUFFER_SIZE = 8192;
        public Account Account { get; set; }
        public bool HasAccount { get { return Account != null; } }
        public ContextEnum CurrentContext { get; set; }

        public LoginClient(Socket socket) : base(socket, BUFFER_SIZE, MessageBuilder.Instance)
        {
            this.OnMessageReceived += LoginClient_OnMessageReceived;
        }

        private void LoginClient_OnMessageReceived(LoginClient client, AbstractMessage msg)
        {
            LOGGER.Debug($"{client} has received message !");
        }
    }
}
