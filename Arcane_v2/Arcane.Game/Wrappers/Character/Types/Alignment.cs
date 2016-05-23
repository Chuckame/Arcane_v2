using Arcane.Protocol.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Game.Wrappers.Character.Types
{
    public class Alignment
    {
        public int CharacterPower { get; internal set; }
        public ushort Dishonor { get; internal set; }
        public sbyte Grade { get; internal set; }
        public AlignmentSideEnum Side { get; internal set; }
        public sbyte Value { get; internal set; }
    }
}
