


















// Generated on 05/16/2016 23:27:29
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class PartyCancelInvitationMessage : AbstractPartyMessage
{

public new const uint Id = 6254;
public override uint MessageId
{
    get { return Id; }
}

public int guestId;
        

public PartyCancelInvitationMessage()
{
}

public PartyCancelInvitationMessage(int partyId, int guestId)
         : base(partyId)
        {
            this.guestId = guestId;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteInt(guestId);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            guestId = reader.ReadInt();
            if (guestId < 0)
                throw new Exception("Forbidden value on guestId = " + guestId + ", it doesn't respect the following condition : guestId < 0");
            

}


}


}