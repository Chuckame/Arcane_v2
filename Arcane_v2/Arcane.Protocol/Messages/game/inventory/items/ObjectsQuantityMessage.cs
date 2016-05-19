


















// Generated on 05/16/2016 23:27:35
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class ObjectsQuantityMessage : AbstractMessage
{

public const uint Id = 6206;
public override uint MessageId
{
    get { return Id; }
}

public Types.ObjectItemQuantity[] objectsUIDAndQty;
        

public ObjectsQuantityMessage()
{
}

public ObjectsQuantityMessage(Types.ObjectItemQuantity[] objectsUIDAndQty)
        {
            this.objectsUIDAndQty = objectsUIDAndQty;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteUShort((ushort)objectsUIDAndQty.Length);
            foreach (var entry in objectsUIDAndQty)
            {
                 entry.Serialize(writer);
            }
            

}

public override void Deserialize(IDataReader reader)
{

var limit = reader.ReadUShort();
            objectsUIDAndQty = new Types.ObjectItemQuantity[limit];
            for (int i = 0; i < limit; i++)
            {
                 objectsUIDAndQty[i] = new Types.ObjectItemQuantity();
                 objectsUIDAndQty[i].Deserialize(reader);
            }
            

}


}


}