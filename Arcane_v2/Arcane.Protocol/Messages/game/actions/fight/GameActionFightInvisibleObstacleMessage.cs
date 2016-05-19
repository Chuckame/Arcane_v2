


















// Generated on 05/16/2016 23:27:22
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class GameActionFightInvisibleObstacleMessage : AbstractGameActionMessage
{

public new const uint Id = 5820;
public override uint MessageId
{
    get { return Id; }
}

public int sourceSpellId;
        

public GameActionFightInvisibleObstacleMessage()
{
}

public GameActionFightInvisibleObstacleMessage(short actionId, int sourceId, int sourceSpellId)
         : base(actionId, sourceId)
        {
            this.sourceSpellId = sourceSpellId;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteInt(sourceSpellId);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            sourceSpellId = reader.ReadInt();
            if (sourceSpellId < 0)
                throw new Exception("Forbidden value on sourceSpellId = " + sourceSpellId + ", it doesn't respect the following condition : sourceSpellId < 0");
            

}


}


}