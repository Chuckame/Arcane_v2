


















// Generated on 05/16/2016 23:27:24
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class NumericWhoIsRequestMessage : AbstractMessage
{

public const uint Id = 6298;
public override uint MessageId
{
    get { return Id; }
}

public int playerId;
        

public NumericWhoIsRequestMessage()
{
}

public NumericWhoIsRequestMessage(int playerId)
        {
            this.playerId = playerId;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(playerId);
            

}

public override void Deserialize(IDataReader reader)
{

playerId = reader.ReadInt();
            if (playerId < 0)
                throw new Exception("Forbidden value on playerId = " + playerId + ", it doesn't respect the following condition : playerId < 0");
            

}


}


}