


















// Generated on 05/16/2016 23:27:27
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class EmotePlayErrorMessage : AbstractMessage
{

public const uint Id = 5688;
public override uint MessageId
{
    get { return Id; }
}

public sbyte emoteId;
        

public EmotePlayErrorMessage()
{
}

public EmotePlayErrorMessage(sbyte emoteId)
        {
            this.emoteId = emoteId;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteSByte(emoteId);
            

}

public override void Deserialize(IDataReader reader)
{

emoteId = reader.ReadSByte();
            

}


}


}