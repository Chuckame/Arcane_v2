using Arcane.Game.Types;
using Arcane.Protocol.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Game.Helpers
{
    public static class PathHelper
    {
        public static IEnumerable<PathNode> GetPathFromKeyMovements(short[] keyMovements)
        {
            var result = new LinkedList<PathNode>();

            foreach (var key in keyMovements)
            {
                result.AddLast(new PathNode { CellId = (short)(key & 4095), Direction = (DirectionsEnum)(key >> 12 & 15) });
            }

            return result;
        }
    }
}
