using Dofus.IO;

namespace Dofus.Files.Elements.SubTypes
{
    public class ParticlesGraphicalElementData : GraphicalElementData
    {
        public override GraphicalElementTypesEnum GraphicalElementType
        {
            get
            {
                return GraphicalElementTypesEnum.Particles;
            }
        }

        public short ScriptId
        { get; set; }

        internal ParticlesGraphicalElementData()
        {
        }
        internal ParticlesGraphicalElementData(int elementId)
            : base(elementId)
        {
        }

        public override void FromRaw(IDataReader reader, int fileVersion)
        {
            this.ScriptId = reader.ReadShort();
        }

        public override void ToRaw(IDataWriter writer, int fileVersion)
        {
            writer.WriteShort(this.ScriptId);
        }
    }
}
