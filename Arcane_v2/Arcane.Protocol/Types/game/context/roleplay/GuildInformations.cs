


















// Generated on 05/16/2016 23:27:38
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class GuildInformations : BasicGuildInformations
{

public new const short Id = 127;
public override short TypeId { get { return Id; } }

public Types.GuildEmblem guildEmblem;
        

public GuildInformations()
{
}

public GuildInformations(int guildId, string guildName, Types.GuildEmblem guildEmblem)
         : base(guildId, guildName)
        {
            this.guildEmblem = guildEmblem;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            guildEmblem.Serialize(writer);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            guildEmblem = new Types.GuildEmblem();
            guildEmblem.Deserialize(reader);
            

}


}


}