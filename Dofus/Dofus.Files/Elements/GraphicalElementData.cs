using Dofus.IO;

namespace Dofus.Files.Elements
{
    public abstract class GraphicalElementData
    {
        public int ElementId
        { get; set; }
        public abstract GraphicalElementTypesEnum GraphicalElementType
        { get; }

        protected GraphicalElementData()
        {

        }

        protected GraphicalElementData(int elementId)
        {
            this.ElementId = elementId;
        }

        public abstract void ToRaw(IDataWriter writer, int fileVersion);

        public abstract void FromRaw(IDataReader reader, int fileVersion);
    }
}
