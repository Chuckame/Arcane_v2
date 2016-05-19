using Arcane.Base.Entities;
using Arcane.Base.Network.GameLink;
using Arcane.Base.Network.GameLink.Messages;
using Arcane.Protocol;
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
        public GameServerEntity ServerInformations { get; }
        public bool HasServerInformations { get { return ServerInformations != null; } }

        public GameLinkClient(Socket socket) : base(socket, BUFFER_SIZE, GameLinkMessageBuilder.Instance)
        {
        }
    }
}
