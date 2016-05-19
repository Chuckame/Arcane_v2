


















// Generated on 05/16/2016 23:27:25
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class ChatServerWithObjectMessage : ChatServerMessage
{

public new const uint Id = 883;
public override uint MessageId
{
    get { return Id; }
}

public Types.ObjectItem[] objects;
        

public ChatServerWithObjectMessage()
{
}

public ChatServerWithObjectMessage(sbyte channel, string content, int timestamp, string fingerprint, int senderId, string senderName, int senderAccountId, Types.ObjectItem[] objects)
         : base(channel, content, timestamp, fingerprint, senderId, senderName, senderAccountId)
        {
            this.objects = objects;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteUShort((ushort)objects.Length);
            foreach (var entry in objects)
            {
                 entry.Serialize(writer);
            }
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            var limit = reader.ReadUShort();
            objects = new Types.ObjectItem[limit];
            for (int i = 0; i < limit; i++)
            {
                 objects[i] = new Types.ObjectItem();
                 objects[i].Deserialize(reader);
            }
            

}


}


}