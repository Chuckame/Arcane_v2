using Chuckame.IO.TCP.Client;
using Chuckame.IO.TCP.Messages;
using Chuckame.IO.TCP.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Base.Network
{
    public abstract class AbstractServerManager<TServer, TClient, TMessage>
        where TMessage : IMessage
        where TClient : IClient<TClient, TMessage>
        where TServer : AbstractBaseServer<TServer, TClient, TMessage>
    {
        public TServer Server { get; }
        public event Action<TClient> OnClientConnected;
        public event Action<TClient> OnClientDisconnected;
        public event Action<TClient> OnClientMessageReceiving;
        public event Action<TClient, TMessage> OnClientMessageReceived;
        public event Action<TClient, TMessage> OnClientMessageSending;
        public event Action<TClient, TMessage> OnClientMessageSent;

        protected AbstractServerManager(TServer server)
        {
            Server = server;
            Server.OnClientAccepted += (serv, client) => OnClientConnected?.Invoke(client);
            Server.OnClientAccepted += Server_OnClientAccepted;
        }

        private void Server_OnClientAccepted(TServer server, TClient client)
        {
            client.OnDisconnected += (c) => OnClientDisconnected?.Invoke(c);
            client.OnMessageReceived += (c, m) => OnClientMessageReceived?.Invoke(c, m);
            client.OnMessageReceiving += (c) => OnClientMessageReceiving?.Invoke(c);
            client.OnMessageSending += (c, m) => OnClientMessageSending?.Invoke(c, m);
            client.OnMessageSent += (c, m) => OnClientMessageSent?.Invoke(c, m);
        }

        public void Start()
        {
            if (Server == null)
                throw new NullReferenceException("This instance must be initialized before.");
            Server.Start();
        }
        public void Stop()
        {
            if (Server == null)
                throw new NullReferenceException("This instance must be initialized before.");
            Server.Stop();
        }
    }
}
