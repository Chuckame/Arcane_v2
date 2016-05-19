using System;
using System.Net;

namespace Arcane.Game.Network
{
    public static class GameServerFactory
    {
        public static GameServer CreateGameServer(IPAddress host, int port, int maxConnections)
        {
            return new GameServer(host, port, maxConnections);
        }
    }
}