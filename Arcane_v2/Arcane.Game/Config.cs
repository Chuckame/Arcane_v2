using Arcane.Protocol.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Game
{
    internal static class Config
    {
        internal static readonly short CharacterCreation_BreedsAvailable = 32767;
        internal static readonly short CharacterCreation_BreedsVisible = 32767;
        internal static readonly bool CharacterCreation_TutorialAvailable = false;
        internal static readonly int GameServerClientIddleTimeout = 60000 * 10;//10 minutes avant déconnexion
        internal static readonly IPAddress GameServerHost = IPAddress.Parse("127.0.0.1");
        internal static readonly int GameServerMaxConnections = 1000;
        internal static readonly int GameServerPort = 5555;
        internal static readonly string MapKey = "649ae451ca33ec53bbcbcc33becf15f4";
        internal static readonly ushort ServerId = 37;
        internal static readonly TimeSpan TicketExpirationTime = new TimeSpan(0, 0, 0, 30, 0);

        internal static readonly short StartCellId = 298;
        internal static readonly DirectionsEnum StartDirection = DirectionsEnum.SOUTH_EAST;
        internal static readonly IReadOnlyDictionary<PlayableBreedEnum, int> BreedsStartMaps = GetBreedsStartMaps();

        private static IReadOnlyDictionary<PlayableBreedEnum, int> GetBreedsStartMaps()
        {
            return new Dictionary<PlayableBreedEnum, int>
            {
                { PlayableBreedEnum.Cra, 81265668 },
                { PlayableBreedEnum.Ecaflip, 81265666 },
                { PlayableBreedEnum.Eniripsa, 81266690 },
                { PlayableBreedEnum.Enutrof, 81264640 },
                { PlayableBreedEnum.Feca, 81264644 },
                { PlayableBreedEnum.Iop, 81266692 },
                { PlayableBreedEnum.Osamodas, 81267714 },
                { PlayableBreedEnum.Pandawa, 81267714 },
                { PlayableBreedEnum.Roublard, 81264646 },
                { PlayableBreedEnum.Sacrieur, 81267712 },
                { PlayableBreedEnum.Sadida, 81265670 },
                { PlayableBreedEnum.Sram, 81266688 },
                { PlayableBreedEnum.Xelor, 81265664 },
                { PlayableBreedEnum.Zobal, 81264642 }
            };
        }
    }
}
