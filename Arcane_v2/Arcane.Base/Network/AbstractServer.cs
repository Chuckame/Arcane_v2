using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Base.Network
{
    public abstract class AbstractServer<TClient> : IServer<TClient>
        where TClient : AbstractBaseClient<TClient>
    {
        private readonly IEnumerable<TClient> _mClients;
        private readonly string _mHost;
        private readonly bool _mIsStarted;
        private readonly int _mPort;

        public event Action<TClient> OnClientAccepted;
        public event Action OnStarted;
        public event Action OnStarting;
        public event Action OnStopped;
        public event Action OnStopping;

        public IEnumerable<TClient> Clients
        {
            get
            {
                return _mClients;
            }
        }

        public string Host
        {
            get
            {
                return _mHost;
            }
        }

        public bool IsStarted
        {
            get
            {
                return _mIsStarted;
            }
        }
        public int Port
        {
            get
            {
                return _mPort;
            }
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
