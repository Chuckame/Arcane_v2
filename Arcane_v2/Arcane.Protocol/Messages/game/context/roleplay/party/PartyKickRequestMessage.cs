


















// Generated on 05/16/2016 23:27:30
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class PartyKickRequestMessage : AbstractPartyMessage
{

public new const uint Id = 5592;
public override uint MessageId
{
    get { return Id; }
}

public int playerId;
        

public PartyKickRequestMessage()
{
}

public PartyKickRequestMessage(int partyId, int playerId)
         : base(partyId)
        {
            this.playerId = playerId;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteInt(playerId);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            playerId = reader.ReadInt();
            if (playerId < 0)
                throw new Exception("Forbidden value on playerId = " + playerId + ", it doesn't respect the following condition : playerId < 0");
            

}


}


}