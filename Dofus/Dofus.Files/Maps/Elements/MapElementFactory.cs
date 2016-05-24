using Dofus.Files.Dofus.Files.Maps.Types;
using Dofus.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dofus.Files.Dofus.Files.Maps.Elements
{
    public static class MapElementFactory
    {
        public static IMapElement GetElementFromType(ElementTypesEnum elementType, MapFile map)
        {
            switch (elementType)
            {
                case ElementTypesEnum.GRAPHICAL:
                    return new GraphicalMapElement(map);
                case ElementTypesEnum.SOUND:
                    return new SoundMapElement(map);
            }
            throw new NotSupportedException($"Unable to read element type '{elementType}'.");
        }
    }
}
