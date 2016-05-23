

















// Generated on 05/22/2016 17:50:28
using System;
using System.Collections.Generic;
using Dofus.Files.GameData;

namespace Arcane.Protocol.Datacenter
{

[D2OClass(Effect.MODULE)]
    
public class Effect : IDataObject
{

private const String MODULE = "Effects";
        public int id;
        public uint descriptionId;
        public int iconId;
        public int characteristic;
        public uint category;
        public String @operator;
        public Boolean showInTooltip;
        public Boolean useDice;
        public Boolean forceMinMax;
        public Boolean boost;
        public Boolean active;
        public Boolean showInSet;
        public int bonusType;
        public Boolean useInFight;
        

}

}