


















// Generated on 05/16/2016 23:27:35
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class InventoryContentMessage : AbstractMessage
{

public const uint Id = 3016;
public override uint MessageId
{
    get { return Id; }
}

public Types.ObjectItem[] objects;
        public int kamas;
        

public InventoryContentMessage()
{
}

public InventoryContentMessage(Types.ObjectItem[] objects, int kamas)
        {
            this.objects = objects;
            this.kamas = kamas;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteUShort((ushort)objects.Length);
            foreach (var entry in objects)
            {
                 entry.Serialize(writer);
            }
            writer.WriteInt(kamas);
            

}

public override void Deserialize(IDataReader reader)
{

var limit = reader.ReadUShort();
            objects = new Types.ObjectItem[limit];
            for (int i = 0; i < limit; i++)
            {
                 objects[i] = new Types.ObjectItem();
                 objects[i].Deserialize(reader);
            }
            kamas = reader.ReadInt();
            if (kamas < 0)
                throw new Exception("Forbidden value on kamas = " + kamas + ", it doesn't respect the following condition : kamas < 0");
            

}


}


}