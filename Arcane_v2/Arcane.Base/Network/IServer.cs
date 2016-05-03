using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Base.Network
{
    public interface IServer<TClient>
        where TClient : IClient<TClient>
    {
        string Host { get; }
        int Port { get; }
        bool IsStarted { get; }
        IEnumerable<TClient> Clients { get; }

        event Action OnStarting;
        event Action OnStarted;
        event Action<TClient> OnClientAccepted;
        event Action OnStopping;
        event Action OnStopped;

        void Start();
        void Stop();
    }
}
