


















// Generated on 05/16/2016 23:27:22
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class AbstractGameActionMessage : AbstractMessage
{

public const uint Id = 1000;
public override uint MessageId
{
    get { return Id; }
}

public short actionId;
        public int sourceId;
        

public AbstractGameActionMessage()
{
}

public AbstractGameActionMessage(short actionId, int sourceId)
        {
            this.actionId = actionId;
            this.sourceId = sourceId;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteShort(actionId);
            writer.WriteInt(sourceId);
            

}

public override void Deserialize(IDataReader reader)
{

actionId = reader.ReadShort();
            if (actionId < 0)
                throw new Exception("Forbidden value on actionId = " + actionId + ", it doesn't respect the following condition : actionId < 0");
            sourceId = reader.ReadInt();
            

}


}


}