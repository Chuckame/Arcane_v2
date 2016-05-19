


















// Generated on 05/16/2016 23:27:35
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class StorageObjectsRemoveMessage : AbstractMessage
{

public const uint Id = 6035;
public override uint MessageId
{
    get { return Id; }
}

public int[] objectUIDList;
        

public StorageObjectsRemoveMessage()
{
}

public StorageObjectsRemoveMessage(int[] objectUIDList)
        {
            this.objectUIDList = objectUIDList;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteUShort((ushort)objectUIDList.Length);
            foreach (var entry in objectUIDList)
            {
                 writer.WriteInt(entry);
            }
            

}

public override void Deserialize(IDataReader reader)
{

var limit = reader.ReadUShort();
            objectUIDList = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 objectUIDList[i] = reader.ReadInt();
            }
            

}


}


}