using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dofus.Files.Dofus.Files.Maps.Types
{
    [Flags]
    public enum MapLosMovEnum
    {
        /// <summary>
        /// Can move on.
        /// </summary>
        Mov = 1,

        /// <summary>
        /// For example, in fight, we can shot through (black cell).
        /// </summary>
        Los = 2,

        /// <summary>
        /// Can move on in fight.
        /// </summary>
        NonWalkableDuringFight = 4,

        /// <summary>
        /// Red placement cell (attacker) in fight.
        /// </summary>
        Red = 8,

        /// <summary>
        /// Blue placement cell (defender) in fight.
        /// </summary>
        Blue = 16,

        /// <summary>
        /// Probably harvestable cell.
        /// </summary>
        FarmCell = 32,

        /// <summary>
        /// To use any flags, cell must have this flag (Visible).
        /// </summary>
        Visible = 64,

        /// <summary>
        /// Can move on in roleplay.
        /// </summary>
        NonWalkableDuringRP = 128
    }
}
