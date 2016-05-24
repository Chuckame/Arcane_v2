using Dofus.IO;

namespace Dofus.Files.Elements.ElementTypes
{
    internal class BlendedGraphicalElementData : NormalGraphicalElementData
    {
        public string BlendMode
        { get; set; }

        public BlendedGraphicalElementData(int elementId, IElementsFile elementsFile)
            : base(elementId, elementsFile)
        {
        }

        public override void ReadFrom(IDataReader reader)
        {
            base.ReadFrom(reader);
            this.BlendMode = reader.ReadUTFBytes((ushort)reader.ReadInt());
        }

        public override void WriteTo(IDataWriter writer)
        {
            base.WriteTo(writer);
            writer.WriteInt(this.BlendMode.Length);
            writer.WriteUTF(this.BlendMode);
        }
    }
}
