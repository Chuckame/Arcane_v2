using Dofus.IO;
using System.Drawing;

namespace Dofus.Files.Elements.ElementTypes
{
    public class NormalGraphicalElementData : GraphicalElementData
    {
        public override GraphicalElementTypesEnum GraphicalElementType
        {
            get { return GraphicalElementTypesEnum.Normal; }
        }
        public int GfxId { get; set; }
        public byte Height { get; set; }
        public bool HorizontalSymmetry { get; set; }
        public Point Origin { get; set; }
        public Point Size { get; set; }

        public NormalGraphicalElementData(int elementId, IElementsFile elementsFile)
            : base(elementId, elementsFile)
        {
        }

        public override void ReadFrom(IDataReader reader)
        {
            this.GfxId = reader.ReadInt();
            this.Height = reader.ReadByte();
            this.HorizontalSymmetry = reader.ReadBoolean();
            this.Origin = new Point(reader.ReadShort(), reader.ReadShort());
            this.Size = new Point(reader.ReadShort(), reader.ReadShort());
        }

        public override void WriteTo(IDataWriter writer)
        {
            writer.WriteInt(this.GfxId);
            writer.WriteByte(this.Height);
            writer.WriteBoolean(this.HorizontalSymmetry);
            writer.WriteShort((short)this.Origin.X);
            writer.WriteShort((short)this.Origin.Y);
            writer.WriteShort((short)this.Size.X);
            writer.WriteShort((short)this.Size.Y);
        }
        public override string ToString()
        {
            return $"{base.ToString()}(gfx:{GfxId})";
        }
    }
}
