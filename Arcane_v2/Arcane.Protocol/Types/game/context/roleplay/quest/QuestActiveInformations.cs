


















// Generated on 05/16/2016 23:27:38
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class QuestActiveInformations : AbstractType
{

public const short Id = 381;
public override short TypeId { get { return Id; } }

public short questId;
        

public QuestActiveInformations()
{
}

public QuestActiveInformations(short questId)
        {
            this.questId = questId;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteShort(questId);
            

}

public override void Deserialize(IDataReader reader)
{

questId = reader.ReadShort();
            if (questId < 0)
                throw new Exception("Forbidden value on questId = " + questId + ", it doesn't respect the following condition : questId < 0");
            

}


}


}