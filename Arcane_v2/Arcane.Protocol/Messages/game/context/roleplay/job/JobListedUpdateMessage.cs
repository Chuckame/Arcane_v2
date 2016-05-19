


















// Generated on 05/16/2016 23:27:28
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class JobListedUpdateMessage : AbstractMessage
{

public const uint Id = 6016;
public override uint MessageId
{
    get { return Id; }
}

public bool addedOrDeleted;
        public sbyte jobId;
        

public JobListedUpdateMessage()
{
}

public JobListedUpdateMessage(bool addedOrDeleted, sbyte jobId)
        {
            this.addedOrDeleted = addedOrDeleted;
            this.jobId = jobId;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteBoolean(addedOrDeleted);
            writer.WriteSByte(jobId);
            

}

public override void Deserialize(IDataReader reader)
{

addedOrDeleted = reader.ReadBoolean();
            jobId = reader.ReadSByte();
            if (jobId < 0)
                throw new Exception("Forbidden value on jobId = " + jobId + ", it doesn't respect the following condition : jobId < 0");
            

}


}


}