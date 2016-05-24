namespace Dofus.Files.Elements.SubTypes
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

        internal BoundingBoxGraphicalElementData()
        {
        }
        internal BoundingBoxGraphicalElementData(int elementId)
            : base(elementId)
        {
        }
    }
}
