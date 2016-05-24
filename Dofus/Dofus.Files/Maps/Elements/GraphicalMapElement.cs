using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dofus.IO;
using System.Drawing;
using Dofus.Files.Dofus.Files.Common;
using Dofus.Files.Dofus.Files.Maps.Types;

namespace Dofus.Files.Dofus.Files.Maps.Elements
{
    public class GraphicalMapElement : IMapElement
    {
        public uint ElementId { get; set; }
        public ColorMultiplicator Hue { get; set; }
        public ColorMultiplicator Shadow { get; set; }
        public Point Offset { get; set; }
        public Point PixelOffset { get; set; }
        public byte Altitude { get; set; }
        public uint Identifier { get; set; }
        public MapFile Map { get; }

        public ElementTypesEnum ElementType
        {
            get
            {
                return ElementTypesEnum.GRAPHICAL;
            }
        }

        public GraphicalMapElement(MapFile map)
        {
            this.Map = map;
        }

        public bool IsIdentified()
        {
            return Identifier > 0;
        }

        public void ReadFrom(IDataReader reader)
        {
            this.ElementId = reader.ReadUInt();
            this.Hue = new ColorMultiplicator(reader.ReadByte(), reader.ReadByte(), reader.ReadByte());
            this.Shadow = new ColorMultiplicator(reader.ReadByte(), reader.ReadByte(), reader.ReadByte());
            this.Offset = new Point();
            this.PixelOffset = new Point();
            if (Map.MapVersion <= 4)
            {
                this.Offset = new Point(reader.ReadByte(), reader.ReadByte());
                this.PixelOffset = new Point((int)(this.Offset.X * AtouinConstants.CELL_HALF_WIDTH), (int)(this.Offset.Y * AtouinConstants.CELL_HALF_HEIGHT));
            }
            else
            {
                this.PixelOffset = new Point(reader.ReadShort(), reader.ReadShort());
                this.Offset = new Point((int)(this.PixelOffset.X / AtouinConstants.CELL_HALF_WIDTH), (int)(this.PixelOffset.Y / AtouinConstants.CELL_HALF_HEIGHT));
            }
            this.Altitude = reader.ReadByte();
            this.Identifier = reader.ReadUInt();
        }

        public void WriteTo(IDataWriter writer)
        {
            writer.WriteUInt(this.ElementId);
            writer.WriteByte((byte)this.Hue.Red);
            writer.WriteByte((byte)this.Hue.Green);
            writer.WriteByte((byte)this.Hue.Blue);
            writer.WriteByte((byte)this.Shadow.Red);
            writer.WriteByte((byte)this.Shadow.Green);
            writer.WriteByte((byte)this.Shadow.Blue);

            if (Map.MapVersion <= 4)
            {
                writer.WriteByte((byte)this.Offset.X);
                writer.WriteByte((byte)this.Offset.Y);
            }
            else
            {
                writer.WriteShort((short)this.PixelOffset.X);
                writer.WriteShort((short)this.PixelOffset.Y);
            }
            writer.WriteByte(this.Altitude);
            writer.WriteUInt(this.Identifier);
        }
    }
}
