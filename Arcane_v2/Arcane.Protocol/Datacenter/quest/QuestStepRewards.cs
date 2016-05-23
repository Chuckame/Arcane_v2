

















// Generated on 05/22/2016 17:50:29
using System;
using System.Collections.Generic;
using Dofus.Files.GameData;

namespace Arcane.Protocol.Datacenter
{

[D2OClass(QuestStepRewards.MODULE)]
    
public class QuestStepRewards : IDataObject
{

private const String MODULE = "QuestStepRewards";
        public uint id;
        public uint stepId;
        public int levelMin;
        public int levelMax;
        public List<List<uint>> itemsReward;
        public List<uint> emotesReward;
        public List<uint> jobsReward;
        public List<uint> spellsReward;
        

}

}