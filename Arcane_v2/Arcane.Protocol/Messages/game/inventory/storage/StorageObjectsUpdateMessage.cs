


















// Generated on 05/16/2016 23:27:35
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class StorageObjectsUpdateMessage : AbstractMessage
{

public const uint Id = 6036;
public override uint MessageId
{
    get { return Id; }
}

public Types.ObjectItem[] objectList;
        

public StorageObjectsUpdateMessage()
{
}

public StorageObjectsUpdateMessage(Types.ObjectItem[] objectList)
        {
            this.objectList = objectList;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteUShort((ushort)objectList.Length);
            foreach (var entry in objectList)
            {
                 entry.Serialize(writer);
            }
            

}

public override void Deserialize(IDataReader reader)
{

var limit = reader.ReadUShort();
            objectList = new Types.ObjectItem[limit];
            for (int i = 0; i < limit; i++)
            {
                 objectList[i] = new Types.ObjectItem();
                 objectList[i].Deserialize(reader);
            }
            

}


}


}