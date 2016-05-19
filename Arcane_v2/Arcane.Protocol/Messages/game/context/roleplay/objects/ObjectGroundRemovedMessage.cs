


















// Generated on 05/16/2016 23:27:29
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class ObjectGroundRemovedMessage : AbstractMessage
{

public const uint Id = 3014;
public override uint MessageId
{
    get { return Id; }
}

public short cell;
        

public ObjectGroundRemovedMessage()
{
}

public ObjectGroundRemovedMessage(short cell)
        {
            this.cell = cell;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteShort(cell);
            

}

public override void Deserialize(IDataReader reader)
{

cell = reader.ReadShort();
            if (cell < 0 || cell > 559)
                throw new Exception("Forbidden value on cell = " + cell + ", it doesn't respect the following condition : cell < 0 || cell > 559");
            

}


}


}