using Arcane.Base.Network.GameLink.Messages;
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
    public class GameLinkClientFactory : IClientFactory<GameLinkClient, AbstractGameLinkMessage>
    {
        private static GameLinkClientFactory _instance = new GameLinkClientFactory();

        public static GameLinkClientFactory Instance
        {
            get
            {
                return _instance;
            }
        }

        public GameLinkClient createClient(Socket socket)
        {
            return new GameLinkClient(socket);
        }
    }
}
