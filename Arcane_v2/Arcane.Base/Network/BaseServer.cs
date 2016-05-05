using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Arcane.Base.Network
{
    public class BaseServer<TServer, TClient> : IServer<TServer, TClient>
        where TClient : IClient<TClient>
        where TServer : BaseServer<TServer, TClient>
    {
        private readonly object _clientsLock;
        private readonly TcpListener _listener;
        private readonly Collection<TClient> _mClients;
        private readonly Mutex _startStopLock;

        public BaseServer(IPAddress host, int port, int maxConnections, IClientFactory<TClient> clientFactory)
        {
            _startStopLock = new Mutex(true, "_startStopLock");
            _clientsLock = new object();
            _mClients = new Collection<TClient>();
            Host = host;
            ClientFactory = clientFactory;
            Port = port;
            IsStarted = false;
            MaxConnections = maxConnections;
            _listener = new TcpListener(host, port);
        }
        public event Action<TServer, TClient> OnClientAccepted;

        public event Action<TServer> OnStarted;
        public event Action<TServer> OnStarting;
        public event Action<TServer> OnStopped;
        public event Action<TServer> OnStopping;

        public IClientFactory<TClient> ClientFactory { get; }

        public IReadOnlyCollection<TClient> Clients
        {
            get
            {
                lock (_clientsLock)
                {
                    return _mClients;
                }
            }
        }

        public IPAddress Host { get; }

        public bool IsStarted { get; private set; }

        public int MaxConnections { get; }

        public int Port { get; }

        public void DisconnectAll()
        {
            lock (_clientsLock)
            {
                var clients = new TClient[_mClients.Count];
                _mClients.CopyTo(clients, 0);
                foreach (var client in clients)
                {
                    client.Disconnect();
                }
            }
        }

        public void Dispose()
        {
            if (IsStarted)
                Stop();
            _startStopLock.Dispose();
        }

        public void Start()
        {
            try
            {
                _startStopLock.WaitOne();
                if (IsStarted)
                    throw new AlreadyStartedException();
                OnStarting?.Invoke((TServer)this);
                _listener.Start();
                BeginAccept();
                IsStarted = true;
                OnStarted?.Invoke((TServer)this);
            }
            finally
            {
                _startStopLock.ReleaseMutex();
            }
        }

        public void Stop()
        {
            try
            {
                _startStopLock.WaitOne();
                if (!IsStarted)
                    throw new AlreadyStoppedException();
                OnStopping?.Invoke((TServer)this);
                _listener.Stop();
                DisconnectAll();
                IsStarted = false;
                OnStopped?.Invoke((TServer)this);
            }
            finally
            {
                _startStopLock.ReleaseMutex();
            }
        }

        private void BeginAccept()
        {
            _listener.BeginAcceptSocket(AcceptCallback, null);
        }

        private void Client_OnDisconnected(TClient client)
        {
            lock (_clientsLock)
            {
                _mClients.Remove(client);
            }
        }

        private void AcceptCallback(IAsyncResult result)
        {
            Socket clientSocket;
            try
            {
                clientSocket = _listener.EndAcceptSocket(result);
            }
            catch (ObjectDisposedException)
            {
                return;
            }
            if (clientSocket != null)
            {
                var count = 0;
                lock (_clientsLock)
                {
                    count = _mClients.Count;
                }
                if (count >= MaxConnections)
                {
                    clientSocket.Close();
                }
                else
                {
                    var client = ClientFactory.createClient(clientSocket);
                    lock (_clientsLock)
                    {
                        _mClients.Add(client);
                    }
                    client.OnDisconnected += Client_OnDisconnected;
                    OnClientAccepted?.Invoke((TServer)this, client);
                }
            }
            if (IsStarted)
            {
                BeginAccept();
            }
        }
    }
}
