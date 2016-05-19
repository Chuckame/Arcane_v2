


















// Generated on 05/16/2016 23:27:26
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class ChallengeResultMessage : AbstractMessage
{

public const uint Id = 6019;
public override uint MessageId
{
    get { return Id; }
}

public sbyte challengeId;
        public bool success;
        

public ChallengeResultMessage()
{
}

public ChallengeResultMessage(sbyte challengeId, bool success)
        {
            this.challengeId = challengeId;
            this.success = success;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteSByte(challengeId);
            writer.WriteBoolean(success);
            

}

public override void Deserialize(IDataReader reader)
{

challengeId = reader.ReadSByte();
            if (challengeId < 0)
                throw new Exception("Forbidden value on challengeId = " + challengeId + ", it doesn't respect the following condition : challengeId < 0");
            success = reader.ReadBoolean();
            

}


}


}