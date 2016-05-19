


















// Generated on 05/16/2016 23:27:32
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class GuildFightLeaveRequestMessage : AbstractMessage
{

public const uint Id = 5715;
public override uint MessageId
{
    get { return Id; }
}

public int taxCollectorId;
        public int characterId;
        

public GuildFightLeaveRequestMessage()
{
}

public GuildFightLeaveRequestMessage(int taxCollectorId, int characterId)
        {
            this.taxCollectorId = taxCollectorId;
            this.characterId = characterId;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(taxCollectorId);
            writer.WriteInt(characterId);
            

}

public override void Deserialize(IDataReader reader)
{

taxCollectorId = reader.ReadInt();
            characterId = reader.ReadInt();
            if (characterId < 0)
                throw new Exception("Forbidden value on characterId = " + characterId + ", it doesn't respect the following condition : characterId < 0");
            

}


}


}