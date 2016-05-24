using Dofus.IO;

namespace Dofus.Files.Elements.SubTypes
{
    internal class BlendedGraphicalElementData : NormalGraphicalElementData
    {
        public string BlendMode
        { get; set; }

        internal BlendedGraphicalElementData()
        {
        }
        internal BlendedGraphicalElementData(int elementId)
            : base(elementId)
        {
        }

        public override void FromRaw(IDataReader reader, int fileVersion)
        {
            base.FromRaw(reader, fileVersion);
            this.BlendMode = reader.ReadUTFBytes((ushort)reader.ReadInt());
        }

        public override void ToRaw(IDataWriter writer, int fileVersion)
        {
            base.ToRaw(writer, fileVersion);
            writer.WriteInt(this.BlendMode.Length);
            writer.WriteUTF(this.BlendMode);
        }
    }
}
