


















// Generated on 05/16/2016 23:27:28
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class JobDescriptionMessage : AbstractMessage
{

public const uint Id = 5655;
public override uint MessageId
{
    get { return Id; }
}

public Types.JobDescription[] jobsDescription;
        

public JobDescriptionMessage()
{
}

public JobDescriptionMessage(Types.JobDescription[] jobsDescription)
        {
            this.jobsDescription = jobsDescription;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteUShort((ushort)jobsDescription.Length);
            foreach (var entry in jobsDescription)
            {
                 entry.Serialize(writer);
            }
            

}

public override void Deserialize(IDataReader reader)
{

var limit = reader.ReadUShort();
            jobsDescription = new Types.JobDescription[limit];
            for (int i = 0; i < limit; i++)
            {
                 jobsDescription[i] = new Types.JobDescription();
                 jobsDescription[i].Deserialize(reader);
            }
            

}


}


}