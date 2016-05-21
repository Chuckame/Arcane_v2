using Arcane.Base.Network.GameLink;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace Arcane.Game.Network.GameLink
{
    public class GameLinkConnector : AbstractGameLinkClient<GameLinkConnector>
    {
        public GameLinkConnector(Socket socket) : base(socket)
        {
        }
    }
}
