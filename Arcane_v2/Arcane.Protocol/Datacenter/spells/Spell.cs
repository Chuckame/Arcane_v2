

















// Generated on 05/22/2016 17:50:29
using System;
using System.Collections.Generic;
using Dofus.Files.GameData;

namespace Arcane.Protocol.Datacenter
{

[D2OClass(Spell.MODULE)]
    
public class Spell : IDataObject
{

private const String MODULE = "Spells";
        public int id;
        public uint nameId;
        public uint descriptionId;
        public uint typeId;
        public String scriptParams;
        public String scriptParamsCritical;
        public int scriptId;
        public int scriptIdCritical;
        public int iconId;
        public List<uint> spellLevels;
        public Boolean useParamCache = true;
        

}

}