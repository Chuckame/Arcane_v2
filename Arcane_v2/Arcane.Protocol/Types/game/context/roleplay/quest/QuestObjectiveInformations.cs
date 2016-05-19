


















// Generated on 05/16/2016 23:27:38
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class QuestObjectiveInformations : AbstractType
{

public const short Id = 385;
public override short TypeId { get { return Id; } }

public short objectiveId;
        public bool objectiveStatus;
        

public QuestObjectiveInformations()
{
}

public QuestObjectiveInformations(short objectiveId, bool objectiveStatus)
        {
            this.objectiveId = objectiveId;
            this.objectiveStatus = objectiveStatus;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteShort(objectiveId);
            writer.WriteBoolean(objectiveStatus);
            

}

public override void Deserialize(IDataReader reader)
{

objectiveId = reader.ReadShort();
            if (objectiveId < 0)
                throw new Exception("Forbidden value on objectiveId = " + objectiveId + ", it doesn't respect the following condition : objectiveId < 0");
            objectiveStatus = reader.ReadBoolean();
            

}


}


}