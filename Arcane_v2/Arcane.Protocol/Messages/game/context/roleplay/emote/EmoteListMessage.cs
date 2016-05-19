


















// Generated on 05/16/2016 23:27:27
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class EmoteListMessage : AbstractMessage
{

public const uint Id = 5689;
public override uint MessageId
{
    get { return Id; }
}

public sbyte[] emoteIds;
        

public EmoteListMessage()
{
}

public EmoteListMessage(sbyte[] emoteIds)
        {
            this.emoteIds = emoteIds;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteUShort((ushort)emoteIds.Length);
            foreach (var entry in emoteIds)
            {
                 writer.WriteSByte(entry);
            }
            

}

public override void Deserialize(IDataReader reader)
{

var limit = reader.ReadUShort();
            emoteIds = new sbyte[limit];
            for (int i = 0; i < limit; i++)
            {
                 emoteIds[i] = reader.ReadSByte();
            }
            

}


}


}