


















// Generated on 05/16/2016 23:27:28
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class JobLevelUpMessage : AbstractMessage
{

public const uint Id = 5656;
public override uint MessageId
{
    get { return Id; }
}

public sbyte newLevel;
        public Types.JobDescription jobsDescription;
        

public JobLevelUpMessage()
{
}

public JobLevelUpMessage(sbyte newLevel, Types.JobDescription jobsDescription)
        {
            this.newLevel = newLevel;
            this.jobsDescription = jobsDescription;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteSByte(newLevel);
            jobsDescription.Serialize(writer);
            

}

public override void Deserialize(IDataReader reader)
{

newLevel = reader.ReadSByte();
            if (newLevel < 0)
                throw new Exception("Forbidden value on newLevel = " + newLevel + ", it doesn't respect the following condition : newLevel < 0");
            jobsDescription = new Types.JobDescription();
            jobsDescription.Deserialize(reader);
            

}


}


}