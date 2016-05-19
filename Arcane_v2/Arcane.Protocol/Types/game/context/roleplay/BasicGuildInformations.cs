


















// Generated on 05/16/2016 23:27:38
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class BasicGuildInformations : AbstractType
{

public const short Id = 365;
public override short TypeId { get { return Id; } }

public int guildId;
        public string guildName;
        

public BasicGuildInformations()
{
}

public BasicGuildInformations(int guildId, string guildName)
        {
            this.guildId = guildId;
            this.guildName = guildName;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(guildId);
            writer.WriteUTF(guildName);
            

}

public override void Deserialize(IDataReader reader)
{

guildId = reader.ReadInt();
            if (guildId < 0)
                throw new Exception("Forbidden value on guildId = " + guildId + ", it doesn't respect the following condition : guildId < 0");
            guildName = reader.ReadUTF();
            

}


}


}