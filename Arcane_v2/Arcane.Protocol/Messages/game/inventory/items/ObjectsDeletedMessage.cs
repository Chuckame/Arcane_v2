


















// Generated on 05/16/2016 23:27:35
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class ObjectsDeletedMessage : AbstractMessage
{

public const uint Id = 6034;
public override uint MessageId
{
    get { return Id; }
}

public int[] objectUID;
        

public ObjectsDeletedMessage()
{
}

public ObjectsDeletedMessage(int[] objectUID)
        {
            this.objectUID = objectUID;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteUShort((ushort)objectUID.Length);
            foreach (var entry in objectUID)
            {
                 writer.WriteInt(entry);
            }
            

}

public override void Deserialize(IDataReader reader)
{

var limit = reader.ReadUShort();
            objectUID = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 objectUID[i] = reader.ReadInt();
            }
            

}


}


}