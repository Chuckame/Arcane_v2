


















// Generated on 05/16/2016 23:27:26
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class GameFightNewRoundMessage : AbstractMessage
{

public const uint Id = 6239;
public override uint MessageId
{
    get { return Id; }
}

public int roundNumber;
        

public GameFightNewRoundMessage()
{
}

public GameFightNewRoundMessage(int roundNumber)
        {
            this.roundNumber = roundNumber;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(roundNumber);
            

}

public override void Deserialize(IDataReader reader)
{

roundNumber = reader.ReadInt();
            if (roundNumber < 0)
                throw new Exception("Forbidden value on roundNumber = " + roundNumber + ", it doesn't respect the following condition : roundNumber < 0");
            

}


}


}