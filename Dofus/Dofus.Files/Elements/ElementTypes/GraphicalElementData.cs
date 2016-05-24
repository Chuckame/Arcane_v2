using Dofus.Files.Dofus.Files.Common;
using Dofus.IO;

namespace Dofus.Files.Elements.ElementTypes
{
    public abstract class GraphicalElementData : IReadable, IWritable
    {
        public int ElementId { get; private set; }
        public abstract GraphicalElementTypesEnum GraphicalElementType { get; }
        public IElementsFile ElementsFile { get; }

        protected GraphicalElementData(int elementId, IElementsFile elementsFile)
        {
            this.ElementId = elementId;
            this.ElementsFile = elementsFile;
        }

        public abstract void ReadFrom(IDataReader reader);
        public abstract void WriteTo(IDataWriter writer);

        public override string ToString()
        {
            return $"{this.GetType().Name}#{ElementId}";
        }
    }
}
