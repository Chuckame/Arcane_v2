


















// Generated on 05/16/2016 23:27:23
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class GameActionFightReflectSpellMessage : AbstractGameActionMessage
{

public new const uint Id = 5531;
public override uint MessageId
{
    get { return Id; }
}

public int targetId;
        

public GameActionFightReflectSpellMessage()
{
}

public GameActionFightReflectSpellMessage(short actionId, int sourceId, int targetId)
         : base(actionId, sourceId)
        {
            this.targetId = targetId;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteInt(targetId);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            targetId = reader.ReadInt();
            

}


}


}