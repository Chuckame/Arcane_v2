

















// Generated on 05/22/2016 17:50:29
using System;
using System.Collections.Generic;
using Dofus.Files.GameData;

namespace Arcane.Protocol.Datacenter
{

[D2OClass(Skill.MODULE)]
    
public class Skill : IDataObject
{

private const String MODULE = "Skills";
        public int id;
        public uint nameId;
        public int parentJobId;
        public Boolean isForgemagus;
        public int modifiableItemType;
        public int gatheredRessourceItem;
        public List<int> craftableItemIds;
        public int interactiveId;
        public String useAnimation;
        public Boolean isRepair;
        public int cursor;
        public Boolean availableInHouse;
        public uint levelMin;
        

}

}