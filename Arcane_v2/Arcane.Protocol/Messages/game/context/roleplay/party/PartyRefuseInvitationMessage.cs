


















// Generated on 05/16/2016 23:27:30
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class PartyRefuseInvitationMessage : AbstractPartyMessage
{

public new const uint Id = 5582;
public override uint MessageId
{
    get { return Id; }
}



public PartyRefuseInvitationMessage()
{
}

public PartyRefuseInvitationMessage(int partyId)
         : base(partyId)
        {
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            

}


}


}