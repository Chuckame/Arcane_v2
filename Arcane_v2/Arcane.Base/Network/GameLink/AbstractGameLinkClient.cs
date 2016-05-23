using Arcane.Base.Entities;
using Arcane.Base.Network.GameLink;
using Arcane.Base.Network.GameLink.Messages;
using Arcane.Protocol;
using Arcane.Protocol.Enums;
using Castle.ActiveRecord;
using Chuckame.IO.TCP.Client;
using Chuckame.IO.TCP.Messages;
using NLog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Arcane.Base.Network.GameLink.LinkMessageHandle;

namespace Arcane.Base.Network.GameLink
{
    public abstract class AbstractGameLinkClient<TClient> : AbstractBaseClient<TClient, AbstractGameLinkMessage>
        where TClient : AbstractBaseClient<TClient, AbstractGameLinkMessage>
    {
        private readonly Logger LOGGER = LogManager.GetCurrentClassLogger(typeof(TClient));
        public const int BUFFER_SIZE = 8192;
        public GameServerEntity ServerInformations { get; set; }
        public bool HasServerInformations { get { return ServerInformations != null; } }
        private Dictionary<Guid, LinkMessageHandle> _handles;

        protected AbstractGameLinkClient(Socket socket) : base(socket, BUFFER_SIZE, GameLinkMessageBuilder.Instance)
        {
            _handles = new Dictionary<Guid, LinkMessageHandle>();
            OnMessageReceived += GameLinkClient_OnMessageReceived;
        }

        public T SendMessageAndWaitResponse<T>(AbstractGameLinkMessage message, int? timeout = null) where T : AbstractGameLinkMessage
        {
            var id = Guid.NewGuid();
            var handle = new LinkMessageHandle();
            _handles.Add(id, handle);
            message.Token = id;
            try
            {
                SendMessage(message);
                handle.WaitMessage(timeout);
                if (!(handle.Message is T))
                    throw new InvalidMessageResponseException($"Response is '{handle.Message.GetType()}' or Expected is '{typeof(T)}'.");
            }
            finally
            {
                _handles.Remove(id);
            }
            return (T)handle.Message;
        }

        private void GameLinkClient_OnMessageReceived(TClient client, AbstractGameLinkMessage message)
        {
            if (message.Token.HasValue && _handles.ContainsKey(message.Token.Value))
            {
                LOGGER.Debug($"Response for message token '{message.Token}'.");
                _handles[message.Token.Value].Set(message);
            }
        }


        [Serializable]
        public class InvalidMessageResponseException : Exception
        {
            public InvalidMessageResponseException() { }
            public InvalidMessageResponseException(string message) : base(message) { }
        }
    }
}
