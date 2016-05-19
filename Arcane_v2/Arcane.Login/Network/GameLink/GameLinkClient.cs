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
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Login.Network.GameLink
{
    public class GameLinkClient : AbstractBaseClient<GameLinkClient, IGameLinkMessage>
    {
        public const int BUFFER_SIZE = 8192;
        public GameServerEntity ServerInformations { get; set; }
        public bool HasServerInformations { get { return ServerInformations != null; } }

        public event Action<GameLinkClient, ServerStatusEnum> OnStatusUpdated;

        public GameLinkClient(Socket socket) : base(socket, BUFFER_SIZE, GameLinkMessageBuilder.Instance)
        {
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
    }
}
