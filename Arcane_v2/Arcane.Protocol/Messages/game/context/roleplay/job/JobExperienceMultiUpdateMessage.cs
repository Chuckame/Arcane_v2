


















// Generated on 05/16/2016 23:27:28
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class JobExperienceMultiUpdateMessage : AbstractMessage
{

public const uint Id = 5809;
public override uint MessageId
{
    get { return Id; }
}

public Types.JobExperience[] experiencesUpdate;
        

public JobExperienceMultiUpdateMessage()
{
}

public JobExperienceMultiUpdateMessage(Types.JobExperience[] experiencesUpdate)
        {
            this.experiencesUpdate = experiencesUpdate;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteUShort((ushort)experiencesUpdate.Length);
            foreach (var entry in experiencesUpdate)
            {
                 entry.Serialize(writer);
            }
            

}

public override void Deserialize(IDataReader reader)
{

var limit = reader.ReadUShort();
            experiencesUpdate = new Types.JobExperience[limit];
            for (int i = 0; i < limit; i++)
            {
                 experiencesUpdate[i] = new Types.JobExperience();
                 experiencesUpdate[i].Deserialize(reader);
            }
            

}


}


}