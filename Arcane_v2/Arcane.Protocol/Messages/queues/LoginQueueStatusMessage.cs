


















// Generated on 05/16/2016 23:27:36
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class LoginQueueStatusMessage : AbstractMessage
{

public const uint Id = 10;
public override uint MessageId
{
    get { return Id; }
}

public ushort position;
        public ushort total;
        

public LoginQueueStatusMessage()
{
}

public LoginQueueStatusMessage(ushort position, ushort total)
        {
            this.position = position;
            this.total = total;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteUShort(position);
            writer.WriteUShort(total);
            

}

public override void Deserialize(IDataReader reader)
{

position = reader.ReadUShort();
            if (position < 0 || position > 65535)
                throw new Exception("Forbidden value on position = " + position + ", it doesn't respect the following condition : position < 0 || position > 65535");
            total = reader.ReadUShort();
            if (total < 0 || total > 65535)
                throw new Exception("Forbidden value on total = " + total + ", it doesn't respect the following condition : total < 0 || total > 65535");
            

}


}


}