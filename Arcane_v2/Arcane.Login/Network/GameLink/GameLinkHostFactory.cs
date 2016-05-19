using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Login.Network.GameLink
{
    public static class GameLinkHostFactory
    {
        public static GameLinkHost CreateLoginServer(IPAddress gameLinkHost, int gameLinkPort, int gameLinkMaxConnections)
        {
            return new GameLinkHost(gameLinkHost, gameLinkPort, gameLinkMaxConnections);
        }
    }
}
