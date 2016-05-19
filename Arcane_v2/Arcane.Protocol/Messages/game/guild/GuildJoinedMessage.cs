


















// Generated on 05/16/2016 23:27:31
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class GuildJoinedMessage : AbstractMessage
{

public const uint Id = 5564;
public override uint MessageId
{
    get { return Id; }
}

public Types.GuildInformations guildInfo;
        public uint memberRights;
        

public GuildJoinedMessage()
{
}

public GuildJoinedMessage(Types.GuildInformations guildInfo, uint memberRights)
        {
            this.guildInfo = guildInfo;
            this.memberRights = memberRights;
        }
        

public override void Serialize(IDataWriter writer)
{

guildInfo.Serialize(writer);
            writer.WriteUInt(memberRights);
            

}

public override void Deserialize(IDataReader reader)
{

guildInfo = new Types.GuildInformations();
            guildInfo.Deserialize(reader);
            memberRights = reader.ReadUInt();
            if (memberRights < 0 || memberRights > 4.294967295E9)
                throw new Exception("Forbidden value on memberRights = " + memberRights + ", it doesn't respect the following condition : memberRights < 0 || memberRights > 4.294967295E9");
            

}


}


}