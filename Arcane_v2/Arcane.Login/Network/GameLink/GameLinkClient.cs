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
    public class GameLinkClient : AbstractGameLinkClient<GameLinkClient>
    {
        private Collection<Account> _mConnectedAccounts;
        public IReadOnlyCollection<Account> ConnectedAccounts { get; }
        private Dictionary<Guid, LinkMessageHandle> _handles;

        public event Action<GameLinkClient, ServerStatusEnum> OnStatusUpdated;
        public event Action<GameLinkClient, Account> OnAccountConnected;
        public event Action<GameLinkClient, Account> OnAccountDisconnected;

        public GameLinkClient(Socket socket) : base(socket)
        {
            _mConnectedAccounts = new Collection<Account>();
            ConnectedAccounts = new ReadOnlyCollection<Account>(_mConnectedAccounts);
            _handles = new Dictionary<Guid, LinkMessageHandle>();
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
        public bool DisconnectAccount(Account account)
        {
            try
            {
                SendMessageAndWaitResponse<ClientDisconnectedMessage>(new RequestClientDisconnectionMessage { AccountId = account.Id }, 1000);
                return true;
            }
            catch (LinkMessageHandle.HandleTimeoutException)
            {
                return false;
            }
        }
    }
}
