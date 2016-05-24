using Dofus.Files.Dofus.Files.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dofus.IO;
using Dofus.Files.Dofus.Files.Utils;
using Dofus.Files.Dofus.Files.Maps.Types;

namespace Dofus.Files.Dofus.Files.Maps
{
    public class MapCellData : IReadable, IWritable
    {
        public short Floor { get; set; }
        public MapLosMovEnum LosMov { get; set; }
        public byte Speed { get; set; }
        public MapChangeDataEnum MapChangeData { get; set; }
        public byte MoveZone { get; set; }
        public MapFile Map { get; }

        public bool Mov
        {
            get
            {
                return LosMov.HasFlag(MapLosMovEnum.Mov);
            }
            set
            {
                LosMov = LosMov.SetFlag(MapLosMovEnum.Mov, value);
            }
        }

        public bool Los
        {
            get
            {
                return LosMov.HasFlag(MapLosMovEnum.Los);
            }
            set
            {
                LosMov = LosMov.SetFlag(MapLosMovEnum.Los, value);
            }
        }

        public bool NonWalkableDuringFight
        {
            get
            {
                return LosMov.HasFlag(MapLosMovEnum.NonWalkableDuringFight);
            }
            set
            {
                LosMov = LosMov.SetFlag(MapLosMovEnum.NonWalkableDuringFight, value);
            }
        }

        public bool Red
        {
            get
            {
                return LosMov.HasFlag(MapLosMovEnum.Red);
            }
            set
            {
                LosMov = LosMov.SetFlag(MapLosMovEnum.Red, value);
            }
        }

        public bool Blue
        {
            get
            {
                return LosMov.HasFlag(MapLosMovEnum.Blue);
            }
            set
            {
                LosMov = LosMov.SetFlag(MapLosMovEnum.Blue, value);
            }
        }

        public bool FarmCell
        {
            get
            {
                return LosMov.HasFlag(MapLosMovEnum.FarmCell);
            }
            set
            {
                LosMov = LosMov.SetFlag(MapLosMovEnum.FarmCell, value);
            }
        }

        public bool Visible
        {
            get
            {
                return LosMov.HasFlag(MapLosMovEnum.Visible);
            }
            set
            {
                LosMov = LosMov.SetFlag(MapLosMovEnum.Visible, value);
            }
        }

        public bool NonWalkableDuringRP
        {
            get
            {
                return LosMov.HasFlag(MapLosMovEnum.NonWalkableDuringRP);
            }
            set
            {
                LosMov = LosMov.SetFlag(MapLosMovEnum.NonWalkableDuringRP, value);
            }
        }

        public MapCellData(MapFile map)
        {
            this.Map = map;
        }

        public void ReadFrom(IDataReader reader)
        {
            this.Floor = (short)(reader.ReadSByte() * 10);
            if (this.Floor != -1280)
            {
                this.LosMov = (MapLosMovEnum)reader.ReadByte();
                this.Speed = reader.ReadByte();
                this.MapChangeData = (MapChangeDataEnum)reader.ReadByte();
                if (this.Map.MapVersion > 5)
                {
                    this.MoveZone = reader.ReadByte();
                }
            }
        }

        public void WriteTo(IDataWriter writer)
        {
            writer.WriteSByte((sbyte)(this.Floor / 10));
            if (this.Floor != -1280)
            {
                writer.WriteByte((byte)this.LosMov);
                writer.WriteByte(this.Speed);
                writer.WriteByte((byte)this.MapChangeData);
                if (Map.MapVersion > 5)
                {
                    writer.WriteByte(this.MoveZone);
                }
            }
        }
    }
}
