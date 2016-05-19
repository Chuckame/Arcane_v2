


















// Generated on 05/16/2016 23:27:36
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class CinematicMessage : AbstractMessage
{

public const uint Id = 6053;
public override uint MessageId
{
    get { return Id; }
}

public short cinematicId;
        

public CinematicMessage()
{
}

public CinematicMessage(short cinematicId)
        {
            this.cinematicId = cinematicId;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteShort(cinematicId);
            

}

public override void Deserialize(IDataReader reader)
{

cinematicId = reader.ReadShort();
            if (cinematicId < 0)
                throw new Exception("Forbidden value on cinematicId = " + cinematicId + ", it doesn't respect the following condition : cinematicId < 0");
            

}


}


}