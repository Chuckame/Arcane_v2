


















// Generated on 05/16/2016 23:27:28
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class HouseGuildRightsMessage : AbstractMessage
{

public const uint Id = 5703;
public override uint MessageId
{
    get { return Id; }
}

public short houseId;
        public Types.GuildInformations guildInfo;
        public uint rights;
        

public HouseGuildRightsMessage()
{
}

public HouseGuildRightsMessage(short houseId, Types.GuildInformations guildInfo, uint rights)
        {
            this.houseId = houseId;
            this.guildInfo = guildInfo;
            this.rights = rights;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteShort(houseId);
            guildInfo.Serialize(writer);
            writer.WriteUInt(rights);
            

}

public override void Deserialize(IDataReader reader)
{

houseId = reader.ReadShort();
            if (houseId < 0)
                throw new Exception("Forbidden value on houseId = " + houseId + ", it doesn't respect the following condition : houseId < 0");
            guildInfo = new Types.GuildInformations();
            guildInfo.Deserialize(reader);
            rights = reader.ReadUInt();
            if (rights < 0 || rights > 4.294967295E9)
                throw new Exception("Forbidden value on rights = " + rights + ", it doesn't respect the following condition : rights < 0 || rights > 4.294967295E9");
            

}


}


}