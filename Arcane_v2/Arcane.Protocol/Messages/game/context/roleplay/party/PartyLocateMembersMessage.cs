


















// Generated on 05/16/2016 23:27:30
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class PartyLocateMembersMessage : AbstractPartyMessage
{

public new const uint Id = 5595;
public override uint MessageId
{
    get { return Id; }
}

public Types.PartyMemberGeoPosition[] geopositions;
        

public PartyLocateMembersMessage()
{
}

public PartyLocateMembersMessage(int partyId, Types.PartyMemberGeoPosition[] geopositions)
         : base(partyId)
        {
            this.geopositions = geopositions;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteUShort((ushort)geopositions.Length);
            foreach (var entry in geopositions)
            {
                 entry.Serialize(writer);
            }
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            var limit = reader.ReadUShort();
            geopositions = new Types.PartyMemberGeoPosition[limit];
            for (int i = 0; i < limit; i++)
            {
                 geopositions[i] = new Types.PartyMemberGeoPosition();
                 geopositions[i].Deserialize(reader);
            }
            

}


}


}