

















// Generated on 05/22/2016 17:50:29
using System;
using System.Collections.Generic;
using Dofus.Files.GameData;

namespace Arcane.Protocol.Datacenter
{

    [D2OClass(QuestObjective.MODULE)]

    public class QuestObjective : IDataObject
    {

        private const String MODULE = "QuestObjectives";
        public uint id;
        public uint stepId;
        public uint typeId;
        public int dialogId;
        public List<uint> parameters;
        public Point coords;
        public QuestObjectiveType type;


    }

}