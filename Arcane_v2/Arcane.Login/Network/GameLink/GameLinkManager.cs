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

namespace Arcane.Login.Network.GameLink
{
    public class GameLinkManager : AbstractServerManager<GameLinkHost, GameLinkClient, IGameLinkMessage>
    {
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
        }

        private void Client_OnStatusUpdated(GameLinkClient server, Protocol.Enums.ServerStatusEnum client)
        {
            OnStatusUpdated?.Invoke(server, client);
        }

        public ServerStatusEnum GetStatus(ushort serverId)
        {
            var server = GetServer(serverId);
            if (server == null)
                throw new KeyNotFoundException($"Server#{serverId} not found !");
            return server.ServerInformations.Status;
        }

        public GameLinkClient GetServer(ushort serverId)
        {
            return Server.Clients.FirstOrDefault(s => s.HasServerInformations && s.ServerInformations.Id.Equals(serverId));
        }
    }
}
