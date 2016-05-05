using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Base.Network
{
    public interface IServer<TServer, TClient> : IDisposable
        where TClient : IClient<TClient>
        where TServer : IServer<TServer, TClient>
    {
        IPAddress Host { get; }
        int Port { get; }
        bool IsStarted { get; }
        IReadOnlyCollection<TClient> Clients { get; }
        IClientFactory<TClient> ClientFactory { get; }

        event Action<TServer, TClient> OnClientAccepted;
        event Action<TServer> OnStarting;
        event Action<TServer> OnStarted;
        event Action<TServer> OnStopping;
        event Action<TServer> OnStopped;

        void Start();
        void Stop();
        void DisconnectAll();
    }
}
