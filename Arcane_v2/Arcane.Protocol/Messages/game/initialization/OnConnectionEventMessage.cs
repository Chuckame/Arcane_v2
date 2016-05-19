


















// Generated on 05/16/2016 23:27:32
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class OnConnectionEventMessage : AbstractMessage
{

public const uint Id = 5726;
public override uint MessageId
{
    get { return Id; }
}

public sbyte eventType;
        

public OnConnectionEventMessage()
{
}

public OnConnectionEventMessage(sbyte eventType)
        {
            this.eventType = eventType;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteSByte(eventType);
            

}

public override void Deserialize(IDataReader reader)
{

eventType = reader.ReadSByte();
            if (eventType < 0)
                throw new Exception("Forbidden value on eventType = " + eventType + ", it doesn't respect the following condition : eventType < 0");
            

}


}


}