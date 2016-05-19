


















// Generated on 05/16/2016 23:27:27
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class NotificationListMessage : AbstractMessage
{

public const uint Id = 6087;
public override uint MessageId
{
    get { return Id; }
}

public int[] flags;
        

public NotificationListMessage()
{
}

public NotificationListMessage(int[] flags)
        {
            this.flags = flags;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteUShort((ushort)flags.Length);
            foreach (var entry in flags)
            {
                 writer.WriteInt(entry);
            }
            

}

public override void Deserialize(IDataReader reader)
{

var limit = reader.ReadUShort();
            flags = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 flags[i] = reader.ReadInt();
            }
            

}


}


}