using Arcane.Base.Entities;
using Arcane.Base.Network;
using Arcane.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Game.Network
{
    public class GameServerManager : AbstractServerManager<GameServer, GameClient, AbstractMessage>
    {
        #region Singleton
        private static readonly GameServerManager _instance = new GameServerManager();

        public static GameServerManager Instance
        {
            get
            {
                return _instance;
            }
        }
        #endregion

        private GameServerManager() : base(GameServerFactory.CreateGameServer(Config.GameServerHost, Config.GameServerPort, Config.GameServerMaxConnections))
        {
        }

        public void DisconnectClientByAccount(Account account)
        {
            if (Server == null)
                throw new NullReferenceException("This instance must be initialized before.");
            if (account == null)
                throw new ArgumentNullException(nameof(account));
            lock (Server.Clients)
            {
                foreach (var client in Server.Clients)
                {
                    if (client.HasAccount && client.Account.Equals(account))
                        client.Disconnect();
                }
            }
        }

        public bool IsAccountConnected(Account account)
        {
            lock (Server.Clients)
            {
                return Server.Clients.Any(a => a.Account.Equals(account));
            }
        }

        public GameClient GetClientByAccount(Account account)
        {
            lock (Server.Clients)
            {
                return Server.Clients.FirstOrDefault(a => a.Account.Equals(account));
            }
        }
    }
}
