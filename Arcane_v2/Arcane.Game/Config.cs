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
        internal static readonly short CharacterCreation_BreedsAvailable = 32767;
        internal static readonly short CharacterCreation_BreedsVisible = 32767;
        internal static readonly bool CharacterCreation_TutorialAvailable = false;
        internal static readonly int GameServerClientIddleTimeout = 60000;
        internal static readonly IPAddress GameServerHost = IPAddress.Parse("127.0.0.1");
        internal static readonly int GameServerMaxConnections = 1000;
        internal static readonly int GameServerPort = 5555;
        internal static readonly ushort ServerId = 37;
        internal static readonly TimeSpan TicketExpirationTime = new TimeSpan(0, 0, 0, 30, 0);
    }
}
