using Dofus.IO;

namespace Dofus.Files.Elements.ElementTypes
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

        public short ScriptId { get; set; }

        public ParticlesGraphicalElementData(int elementId, IElementsFile elementsFile)
            : base(elementId, elementsFile)
        {
        }

        public override void ReadFrom(IDataReader reader)
        {
            this.ScriptId = reader.ReadShort();
        }

        public override void WriteTo(IDataWriter writer)
        {
            writer.WriteShort(this.ScriptId);
        }
    }
}
