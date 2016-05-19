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

        protected AbstractServerManager(TServer server)
        {
            Server = server;
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
