using Arcane.Protocol.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Game.Wrappers.Character.Types
{
    public class Disposition
    {
        public short CellId { get; set; }
        public DirectionsEnum Direction { get; set; }
    }
}
