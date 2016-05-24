using System;
using Dofus.Files.Elements.ElementTypes;

namespace Dofus.Files.Elements
{
    public static class GraphicalElementDataFactory
    {
        public static GraphicalElementData GetGraphicalElementData(GraphicalElementTypesEnum edType, int elementId, IElementsFile elementsFile)
        {
            switch (edType)
            {
                case GraphicalElementTypesEnum.Normal:
                    return new NormalGraphicalElementData(elementId, elementsFile);
                case GraphicalElementTypesEnum.BoundingBox:
                    return new BoundingBoxGraphicalElementData(elementId, elementsFile);
                case GraphicalElementTypesEnum.Animated:
                    return new AnimatedGraphicalElementData(elementId, elementsFile);
                case GraphicalElementTypesEnum.Entity:
                    return new EntityGraphicalElementData(elementId, elementsFile);
                case GraphicalElementTypesEnum.Particles:
                    return new ParticlesGraphicalElementData(elementId, elementsFile);
                case GraphicalElementTypesEnum.Blended:
                    return new BlendedGraphicalElementData(elementId, elementsFile);
            }
            throw new NotSupportedException($"Unknown graphical element data type {edType} for element {elementId} !");
        }
    }
}
