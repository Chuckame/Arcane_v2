using Dofus.Files.Dofus.Files.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dofus.IO;
using System.Drawing;

namespace Dofus.Files.Dofus.Files.Maps
{
    public class MapFixture : IReadable, IWritable
    {
        public int FixtureId { get; set; }
        public Point Offset { get; set; }
        public byte RedMultiplier { get; set; }
        public byte GreenMultiplier { get; set; }
        public byte BlueMultiplier { get; set; }
        public byte Alpha { get; set; }
        public short XScale { get; set; }
        public short YScale { get; set; }
        public short Rotation { get; set; }

        public int Hue
        {
            get
            {
                return this.RedMultiplier | this.GreenMultiplier | this.BlueMultiplier;
            }
        }

        public Color ColorMultiplier
        {
            get
            {
                return Color.FromArgb(this.RedMultiplier, this.GreenMultiplier, this.BlueMultiplier);
            }
        }

        public void ReadFrom(IDataReader reader)
        {
            this.FixtureId = reader.ReadInt();
            this.Offset = new Point(reader.ReadShort(), reader.ReadShort());
            this.Rotation = reader.ReadShort();
            this.XScale = reader.ReadShort();
            this.YScale = reader.ReadShort();
            this.RedMultiplier = reader.ReadByte();
            this.GreenMultiplier = reader.ReadByte();
            this.BlueMultiplier = reader.ReadByte();
            this.Alpha = reader.ReadByte();
        }

        public void WriteTo(IDataWriter writer)
        {
            writer.WriteInt(this.FixtureId);
            writer.WriteShort((short)this.Offset.X);
            writer.WriteShort((short)this.Offset.Y);
            writer.WriteShort(this.Rotation);
            writer.WriteShort(this.XScale);
            writer.WriteShort(this.YScale);
            writer.WriteByte(this.RedMultiplier);
            writer.WriteByte(this.GreenMultiplier);
            writer.WriteByte(this.BlueMultiplier);
            writer.WriteByte(this.Alpha);
        }
    }
}
