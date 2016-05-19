using System;
using Dofus.Files.Elements.SubTypes;

namespace Dofus.Files.Elements
{
    public static class GraphicalElementDataFactory
    {
        public static GraphicalElementData GetGraphicalElementData(int elementId, GraphicalElementTypesEnum edType)
        {
            switch (edType)
            {
                case GraphicalElementTypesEnum.Normal:
                    return new NormalGraphicalElementData(elementId);
                case GraphicalElementTypesEnum.BoundingBox:
                    return new BoundingBoxGraphicalElementData(elementId);
                case GraphicalElementTypesEnum.Animated:
                    return new AnimatedGraphicalElementData(elementId);
                case GraphicalElementTypesEnum.Entity:
                    return new EntityGraphicalElementData(elementId);
                case GraphicalElementTypesEnum.Particles:
                    return new ParticlesGraphicalElementData(elementId);
                case GraphicalElementTypesEnum.Blended:
                    return new BlendedGraphicalElementData(elementId);
            }
            throw new Exception($"Unknown graphical element data type {edType} for element {elementId} !");
        }
    }
}
