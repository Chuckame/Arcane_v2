using Arcane.Protocol.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Game.Types
{
    public class PathNode
    {
        public short CellId { get; set; }
        public DirectionsEnum Direction { get; set; }
    }
}
