


















// Generated on 05/16/2016 23:27:37
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class PartsListMessage : AbstractMessage
{

public const uint Id = 1502;
public override uint MessageId
{
    get { return Id; }
}

public Types.ContentPart[] parts;
        

public PartsListMessage()
{
}

public PartsListMessage(Types.ContentPart[] parts)
        {
            this.parts = parts;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteUShort((ushort)parts.Length);
            foreach (var entry in parts)
            {
                 entry.Serialize(writer);
            }
            

}

public override void Deserialize(IDataReader reader)
{

var limit = reader.ReadUShort();
            parts = new Types.ContentPart[limit];
            for (int i = 0; i < limit; i++)
            {
                 parts[i] = new Types.ContentPart();
                 parts[i].Deserialize(reader);
            }
            

}


}


}