


















// Generated on 05/16/2016 23:27:28
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class JobCrafterDirectoryListRequestMessage : AbstractMessage
{

public const uint Id = 6047;
public override uint MessageId
{
    get { return Id; }
}

public sbyte jobId;
        

public JobCrafterDirectoryListRequestMessage()
{
}

public JobCrafterDirectoryListRequestMessage(sbyte jobId)
        {
            this.jobId = jobId;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteSByte(jobId);
            

}

public override void Deserialize(IDataReader reader)
{

jobId = reader.ReadSByte();
            if (jobId < 0)
                throw new Exception("Forbidden value on jobId = " + jobId + ", it doesn't respect the following condition : jobId < 0");
            

}


}


}