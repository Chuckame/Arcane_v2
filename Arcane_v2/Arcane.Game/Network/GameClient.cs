using Arcane.Base.Entities;
using Arcane.Game.Wrappers;
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
        public CharacterWrapper Character { get; set; }
        public bool HasCharacter { get { return Character != null; } }

        public GameClient(Socket socket, int iddleTimeoutDisconnection) : base(socket, BUFFER_SIZE, MessageBuilder.Instance, iddleTimeoutDisconnection)
        {
            this.OnMessageReceived += GameClient_OnMessageReceived;
            OnIddleTimeout += GameClient_OnIddleTimeout;
        }

        private void GameClient_OnIddleTimeout(GameClient obj)
        {
            SendMessage(new SystemMessageDisplayMessage(true, 1, new string[0]));//Vous êtes resté inactif trop longtemps.
        }

        private void GameClient_OnMessageReceived(GameClient arg1, AbstractMessage arg2)
        {
            LOGGER.Debug($"{arg2} received !");
        }
    }
}
