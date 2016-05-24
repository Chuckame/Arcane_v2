using Dofus.IO;

namespace Dofus.Files.Elements.ElementTypes
{
    public class AnimatedGraphicalElementData : NormalGraphicalElementData
    {
        public int MinDelay { get; set; }
        public int MaxDelay { get; set; }

        public AnimatedGraphicalElementData(int elementId, IElementsFile elementsFile)
            : base(elementId, elementsFile)
        {
        }

        public override void ReadFrom(IDataReader reader)
        {
            base.ReadFrom(reader);
            if (ElementsFile.FileVersion == 4)
            {
                this.MinDelay = reader.ReadInt();
                this.MaxDelay = reader.ReadInt();
            }
        }

        public override void WriteTo(IDataWriter writer)
        {
            base.WriteTo(writer);
            if (ElementsFile.FileVersion == 4)
            {
                writer.WriteInt(this.MinDelay);
                writer.WriteInt(this.MaxDelay);
            }
        }
    }
}
