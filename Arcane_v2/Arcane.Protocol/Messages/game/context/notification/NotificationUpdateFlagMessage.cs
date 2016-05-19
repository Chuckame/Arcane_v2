


















// Generated on 05/16/2016 23:27:27
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class NotificationUpdateFlagMessage : AbstractMessage
{

public const uint Id = 6090;
public override uint MessageId
{
    get { return Id; }
}

public short index;
        

public NotificationUpdateFlagMessage()
{
}

public NotificationUpdateFlagMessage(short index)
        {
            this.index = index;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteShort(index);
            

}

public override void Deserialize(IDataReader reader)
{

index = reader.ReadShort();
            if (index < 0)
                throw new Exception("Forbidden value on index = " + index + ", it doesn't respect the following condition : index < 0");
            

}


}


}