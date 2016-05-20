using Arcane.Base.Entities;
using Arcane.Base.Network.GameLink;
using Arcane.Base.Network.GameLink.Messages;
using Arcane.Protocol;
using Arcane.Protocol.Enums;
using Castle.ActiveRecord;
using Chuckame.IO.TCP.Client;
using Chuckame.IO.TCP.Messages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Arcane.Login.Network.GameLink
{
    public class GameLinkClient : AbstractBaseClient<GameLinkClient, AbstractGameLinkMessage>
    {
        public const int BUFFER_SIZE = 8192;
        public GameServerEntity ServerInformations { get; set; }
        public bool HasServerInformations { get { return ServerInformations != null; } }
        private Collection<Account> _mConnectedAccounts;
        public IReadOnlyCollection<Account> ConnectedAccounts { get; }
        private Dictionary<Guid, LinkMessageHandle> _handles;

        public event Action<GameLinkClient, ServerStatusEnum> OnStatusUpdated;
        public event Action<GameLinkClient, Account> OnAccountConnected;
        public event Action<GameLinkClient, Account> OnAccountDisconnected;

        public GameLinkClient(Socket socket) : base(socket, BUFFER_SIZE, GameLinkMessageBuilder.Instance)
        {
            _mConnectedAccounts = new Collection<Account>();
            ConnectedAccounts = new ReadOnlyCollection<Account>(_mConnectedAccounts);
            _handles = new Dictionary<Guid, LinkMessageHandle>();
            OnMessageReceived += GameLinkClient_OnMessageReceived;
        }

        public void UpdateStatus(ServerStatusEnum newStatus)
        {
            if (HasServerInformations && ServerInformations.Status != newStatus)
            {
                using (new SessionScope())
                {
                    ServerInformations.Status = newStatus;
                    ServerInformations.Update();
                }
                OnStatusUpdated?.Invoke(this, newStatus);
            }
        }

        public bool IsAccountConnected(Account account)
        {
            return ConnectedAccounts.Contains(account);
        }
        
        public void RemoveAccount(Account account)
        {
            if (IsAccountConnected(account))
            {
                _mConnectedAccounts.Add(account);
                OnAccountDisconnected?.Invoke(this, account);
            }
        }

        public void AddAccount(Account account)
        {
            if (!IsAccountConnected(account))
            {
                _mConnectedAccounts.Add(account);
                OnAccountConnected?.Invoke(this, account);
            }
        }
        public void DisconnectAccount(Account account)
        {
            try
            {
                SendMessageAndWaitResponse<ClientDisconnectedMessage>(new RequestClientDisconnectionMessage { AccountId = account.Id }, 1000);
            }
            catch (LinkMessageHandle.HandleTimeoutException)
            {
                //timeout
                throw new NotImplementedException();
            }
        }

        public T SendMessageAndWaitResponse<T>(AbstractGameLinkMessage message, int? timeout = null) where T : AbstractGameLinkMessage
        {
            var id = Guid.NewGuid();
            var handle = new LinkMessageHandle();
            _handles.Add(id, handle);
            message.Token = id;
            try
            {
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

        private void GameLinkClient_OnMessageReceived(GameLinkClient client, AbstractGameLinkMessage message)
        {
            if (message.HasToken())
            {
                _handles[message.Token].Set(message);
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
