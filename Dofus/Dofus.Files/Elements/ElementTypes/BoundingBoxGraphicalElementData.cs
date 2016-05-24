namespace Dofus.Files.Elements.ElementTypes
{
    public class BoundingBoxGraphicalElementData : NormalGraphicalElementData
    {
        public override GraphicalElementTypesEnum GraphicalElementType
        {
            get
            {
                return GraphicalElementTypesEnum.BoundingBox;
            }
        }

        public BoundingBoxGraphicalElementData(int elementId, IElementsFile elementsFile)
            : base(elementId, elementsFile)
        {
        }
    }
}
