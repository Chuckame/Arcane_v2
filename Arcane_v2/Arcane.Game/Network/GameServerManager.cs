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
    public class GameServerManager
    {
        #region Singleton
        private static GameServerManager _instance = new GameServerManager();

        public static GameServerManager Instance
        {
            get
            {
                return _instance;
            }
        }

        private GameServer server;

        private GameServerManager()
        {
        }
        #endregion

        public void Initialize(IPAddress host, int port, int maxConnections)
        {
            server = new GameServer(host, port, maxConnections);
        }

        public void Start()
        {
            if (server == null)
                throw new NullReferenceException("This instance must be initialized before.");
            server.Start();
        }
        public void Stop()
        {
            if (server == null)
                throw new NullReferenceException("This instance must be initialized before.");
            server.Stop();
        }

        public void DisconnectClientByAccount(Account account)
        {
            if (server == null)
                throw new NullReferenceException("This instance must be initialized before.");
            if (account == null)
                throw new ArgumentNullException(nameof(account));
            foreach (var client in server.Clients)
            {
                if (client.HasAccount && client.Account.Equals(account))
                    client.Disconnect();
            }
        }
    }
    //public class GameServerManager : AbstractServerManager<GameServer, GameClient, AbstractMessage>
    //{
    //    #region Singleton
    //    private static GameServerManager _instance = new GameServerManager();

    //    public static GameServerManager Instance
    //    {
    //        get
    //        {
    //            return _instance;
    //        }
    //    }
    //    #endregion

    //    private GameServerManager() : base(LoginServerFactory.CreateLoginServer(Config.LoginServerHost, Config.LoginServerPort, Config.LoginMaxConnections))
    //    {
    //    }

    //    public void DisconnectClientByAccount(Account account)
    //    {
    //        if (Server == null)
    //            throw new NullReferenceException("This instance must be initialized before.");
    //        if (account == null)
    //            throw new ArgumentNullException(nameof(account));
    //        foreach (var client in Server.Clients)
    //        {
    //            if (client.HasAccount && client.Account.Equals(account))
    //                client.Disconnect();
    //        }
    //    }
    //}
}
