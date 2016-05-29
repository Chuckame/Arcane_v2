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
        private CharacterWrapper Character { get; }

        public Disposition(CharacterWrapper character)
        {
            Character = character;
        }

        public short CellId
        {
            get
            {
                return Character.CellId;
            }
            set
            {
                if (Character.CellId != value)
                {
                    Character.CellId = value;
                }
            }
        }
        public DirectionsEnum Direction
        {
            get
            {
                return Character.Direction;
            }
            set
            {
                if (Character.Direction != value)
                {
                    Character.Direction = value;
                }
            }
        }
    }
}
