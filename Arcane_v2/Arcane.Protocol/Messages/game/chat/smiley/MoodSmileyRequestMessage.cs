


















// Generated on 05/16/2016 23:27:25
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class MoodSmileyRequestMessage : AbstractMessage
{

public const uint Id = 6192;
public override uint MessageId
{
    get { return Id; }
}

public sbyte smileyId;
        

public MoodSmileyRequestMessage()
{
}

public MoodSmileyRequestMessage(sbyte smileyId)
        {
            this.smileyId = smileyId;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteSByte(smileyId);
            

}

public override void Deserialize(IDataReader reader)
{

smileyId = reader.ReadSByte();
            

}


}


}