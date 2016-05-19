using Arcane.Base.Entities;
using Arcane.Base.Network;
using Arcane.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Login.Network
{
    public class LoginServerManager: AbstractServerManager<LoginServer, LoginClient, AbstractMessage>
    {
        #region Singleton
        private static LoginServerManager _instance = new LoginServerManager();

        public static LoginServerManager Instance
        {
            get
            {
                return _instance;
            }
        }
        #endregion

        private LoginServerManager() : base(LoginServerFactory.CreateLoginServer(Config.LoginServerHost, Config.LoginServerPort, Config.LoginMaxConnections))
        {
        }
        
        public void DisconnectClientByAccount(Account account)
        {
            if (Server == null)
                throw new NullReferenceException("This instance must be initialized before.");
            if (account == null)
                throw new ArgumentNullException(nameof(account));
            foreach (var client in Server.Clients)
            {
                if (client.HasAccount && client.Account.Equals(account))
                    client.Disconnect();
            }
        }
    }
}
