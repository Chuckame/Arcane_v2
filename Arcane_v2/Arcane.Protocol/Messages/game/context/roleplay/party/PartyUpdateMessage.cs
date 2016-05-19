


















// Generated on 05/16/2016 23:27:30
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class PartyUpdateMessage : AbstractPartyEventMessage
{

public new const uint Id = 5575;
public override uint MessageId
{
    get { return Id; }
}

public Types.PartyMemberInformations memberInformations;
        

public PartyUpdateMessage()
{
}

public PartyUpdateMessage(int partyId, Types.PartyMemberInformations memberInformations)
         : base(partyId)
        {
            this.memberInformations = memberInformations;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteShort(memberInformations.TypeId);
            memberInformations.Serialize(writer);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            memberInformations = Types.ProtocolTypeManager.GetInstance<Types.PartyMemberInformations>(reader.ReadShort());
            memberInformations.Deserialize(reader);
            

}


}


}