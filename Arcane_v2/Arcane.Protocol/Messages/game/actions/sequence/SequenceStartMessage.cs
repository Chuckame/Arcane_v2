


















// Generated on 05/16/2016 23:27:23
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class SequenceStartMessage : AbstractMessage
{

public const uint Id = 955;
public override uint MessageId
{
    get { return Id; }
}

public sbyte sequenceType;
        public int authorId;
        

public SequenceStartMessage()
{
}

public SequenceStartMessage(sbyte sequenceType, int authorId)
        {
            this.sequenceType = sequenceType;
            this.authorId = authorId;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteSByte(sequenceType);
            writer.WriteInt(authorId);
            

}

public override void Deserialize(IDataReader reader)
{

sequenceType = reader.ReadSByte();
            authorId = reader.ReadInt();
            

}


}


}