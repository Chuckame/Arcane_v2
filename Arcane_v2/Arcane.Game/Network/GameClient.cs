using Arcane.Base.Entities;
using Arcane.Protocol;
using Arcane.Protocol.Messages;
using Chuckame.IO.TCP.Client;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Game.Network
{
    public class GameClient : AbstractBaseClient<GameClient, AbstractMessage>
    {
        private static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();
        public const int BUFFER_SIZE = 8192;
        public string ClientKey { get; set; }
        public Account Account { get; set; }
        public bool HasAccount { get { return Account != null; } }
        public ContextEnum CurrentContext { get; set; }

        public GameClient(Socket socket, int iddleTimeoutDisconnection) : base(socket, BUFFER_SIZE, MessageBuilder.Instance, iddleTimeoutDisconnection)
        {
            this.OnMessageReceived += GameClient_OnMessageReceived;
        }

        private void GameClient_OnMessageReceived(GameClient arg1, AbstractMessage arg2)
        {
            LOGGER.Debug($"{arg2} received !");
        }
    }
}
