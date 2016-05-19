


















// Generated on 05/16/2016 23:27:26
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class ChallengeTargetsListRequestMessage : AbstractMessage
{

public const uint Id = 5614;
public override uint MessageId
{
    get { return Id; }
}

public sbyte challengeId;
        

public ChallengeTargetsListRequestMessage()
{
}

public ChallengeTargetsListRequestMessage(sbyte challengeId)
        {
            this.challengeId = challengeId;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteSByte(challengeId);
            

}

public override void Deserialize(IDataReader reader)
{

challengeId = reader.ReadSByte();
            if (challengeId < 0)
                throw new Exception("Forbidden value on challengeId = " + challengeId + ", it doesn't respect the following condition : challengeId < 0");
            

}


}


}