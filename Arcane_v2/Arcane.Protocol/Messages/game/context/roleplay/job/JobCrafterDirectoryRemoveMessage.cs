


















// Generated on 05/16/2016 23:27:28
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class JobCrafterDirectoryRemoveMessage : AbstractMessage
{

public const uint Id = 5653;
public override uint MessageId
{
    get { return Id; }
}

public sbyte jobId;
        public int playerId;
        

public JobCrafterDirectoryRemoveMessage()
{
}

public JobCrafterDirectoryRemoveMessage(sbyte jobId, int playerId)
        {
            this.jobId = jobId;
            this.playerId = playerId;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteSByte(jobId);
            writer.WriteInt(playerId);
            

}

public override void Deserialize(IDataReader reader)
{

jobId = reader.ReadSByte();
            if (jobId < 0)
                throw new Exception("Forbidden value on jobId = " + jobId + ", it doesn't respect the following condition : jobId < 0");
            playerId = reader.ReadInt();
            if (playerId < 0)
                throw new Exception("Forbidden value on playerId = " + playerId + ", it doesn't respect the following condition : playerId < 0");
            

}


}


}