


















// Generated on 05/16/2016 23:27:29
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class PartyCancelInvitationNotificationMessage : AbstractPartyEventMessage
{

public new const uint Id = 6251;
public override uint MessageId
{
    get { return Id; }
}

public int cancelerId;
        public int guestId;
        

public PartyCancelInvitationNotificationMessage()
{
}

public PartyCancelInvitationNotificationMessage(int partyId, int cancelerId, int guestId)
         : base(partyId)
        {
            this.cancelerId = cancelerId;
            this.guestId = guestId;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteInt(cancelerId);
            writer.WriteInt(guestId);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            cancelerId = reader.ReadInt();
            if (cancelerId < 0)
                throw new Exception("Forbidden value on cancelerId = " + cancelerId + ", it doesn't respect the following condition : cancelerId < 0");
            guestId = reader.ReadInt();
            if (guestId < 0)
                throw new Exception("Forbidden value on guestId = " + guestId + ", it doesn't respect the following condition : guestId < 0");
            

}


}


}