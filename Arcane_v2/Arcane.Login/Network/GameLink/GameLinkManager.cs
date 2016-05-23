using Arcane.Base.Common;
using Arcane.Base.Network;
using Arcane.Base.Network.GameLink.Messages;
using Arcane.Protocol.Enums;
using Chuckame.IO.TCP.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcane.Base.Entities;
using NLog;
using static Arcane.Base.Network.GameLink.LinkMessageHandle;

namespace Arcane.Login.Network.GameLink
{
    public class GameLinkManager : AbstractServerManager<GameLinkHost, GameLinkClient, AbstractGameLinkMessage>
    {
        private static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();
        #region Singleton
        private static GameLinkManager _instance = new GameLinkManager();

        public static GameLinkManager Instance
        {
            get
            {
                return _instance;
            }
        }
        #endregion
        public event Action<GameLinkClient, ServerStatusEnum> OnStatusUpdated;

        private GameLinkManager() : base(GameLinkHostFactory.CreateLoginServer(CommonConfig.GameLinkHost, CommonConfig.GameLinkPort, CommonConfig.GameLinkMaxConnections))
        {
            Server.OnClientAccepted += Server_OnClientAccepted;
        }

        private void Server_OnClientAccepted(GameLinkHost server, GameLinkClient client)
        {
            client.OnStatusUpdated += Client_OnStatusUpdated;
            client.OnDisconnected += Client_OnDisconnected;
        }

        private void Client_OnDisconnected(GameLinkClient client)
        {
            client.UpdateStatus(ServerStatusEnum.OFFLINE);
        }

        private void Client_OnStatusUpdated(GameLinkClient server, ServerStatusEnum status)
        {
            OnStatusUpdated?.Invoke(server, status);
        }

        public ServerStatusEnum GetLiveStatus(ushort serverId)
        {
            var server = GetServer(serverId);
            if (server == null)
                return ServerStatusEnum.OFFLINE;
            return server.ServerInformations.Status;
        }

        public GameLinkClient GetServer(ushort serverId)
        {
            return GetValidServers().FirstOrDefault(s => s.ServerInformations.Id.Equals(serverId));
        }

        public void ForEachValidServer(Action<GameLinkClient> action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));
            foreach (var server in GetValidServers())
            {
                action(server);
            }
        }

        public GameLinkClient[] GetValidServers()
        {
            GameLinkClient[] servers;
            lock (this)
            {
                servers = Server.Clients.Where(x => x.HasServerInformations).ToArray();
            }
            return servers;
        }

        public bool IsServerExists(ushort serverId)
        {
            lock (this)
            {
                return GetValidServers().Any(s => s.ServerInformations.Id.Equals(serverId));
            }
        }

        public void DisconnectClientByAccount(Account account)
        {
            var serverClient = GetServerByAccount(account);
            if (serverClient != null)
            {
                serverClient.DisconnectAccount(account);
            }
        }

        public GameLinkClient GetServerByAccount(Account account)
        {
            lock (this)
            {
                return GetValidServers().FirstOrDefault(x => x.IsAccountConnected(account));
            }
        }
    }
}
