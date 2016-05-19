using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Game
{
    class Config
    {
        internal static readonly IPAddress GameServerHost = IPAddress.Parse("127.0.0.1");
        internal static readonly int GameServerMaxConnections = 1000;
        internal static readonly int GameServerPort = 5555;
    }
}
