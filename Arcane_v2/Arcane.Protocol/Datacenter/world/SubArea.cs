

















// Generated on 05/22/2016 17:50:29
using System;
using System.Collections.Generic;
using Dofus.Files.GameData;

namespace Arcane.Protocol.Datacenter
{

    [D2OClass(SubArea.MODULE)]

    public class SubArea : IDataObject
    {

        private const String MODULE = "SubAreas";
        public int id;
        public uint nameId;
        public int areaId;
        public List<AmbientSound> ambientSounds;
        public List<uint> mapIds;
        public Rectangle bounds;
        public List<int> shape;
        public List<uint> customWorldMap;
        public int packId;


    }

}