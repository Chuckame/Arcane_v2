


















// Generated on 05/16/2016 23:27:32
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class GuildFightJoinRequestMessage : AbstractMessage
{

public const uint Id = 5717;
public override uint MessageId
{
    get { return Id; }
}

public int taxCollectorId;
        

public GuildFightJoinRequestMessage()
{
}

public GuildFightJoinRequestMessage(int taxCollectorId)
        {
            this.taxCollectorId = taxCollectorId;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(taxCollectorId);
            

}

public override void Deserialize(IDataReader reader)
{

taxCollectorId = reader.ReadInt();
            

}


}


}