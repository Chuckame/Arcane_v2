using Arcane.Protocol;
using Chuckame.IO.TCP.Client;
using System.Net.Sockets;

namespace Arcane.Game.Network
{
    public class GameClientFactory : IClientFactory<GameClient, AbstractMessage>
    {
        private static GameClientFactory _instance = new GameClientFactory();

        public static GameClientFactory Instance
        {
            get
            {
                return _instance;
            }
        }

        public GameClient createClient(Socket socket)
        {
            return new GameClient(socket);
        }
    }
}