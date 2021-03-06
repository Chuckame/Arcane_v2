


















// Generated on 05/16/2016 23:27:29
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class PartyKickedByMessage : AbstractPartyMessage
{

public new const uint Id = 5590;
public override uint MessageId
{
    get { return Id; }
}

public int kickerId;
        

public PartyKickedByMessage()
{
}

public PartyKickedByMessage(int partyId, int kickerId)
         : base(partyId)
        {
            this.kickerId = kickerId;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteInt(kickerId);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            kickerId = reader.ReadInt();
            if (kickerId < 0)
                throw new Exception("Forbidden value on kickerId = " + kickerId + ", it doesn't respect the following condition : kickerId < 0");
            

}


}


}