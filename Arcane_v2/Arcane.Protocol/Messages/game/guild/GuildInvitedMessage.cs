


















// Generated on 05/16/2016 23:27:31
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class GuildInvitedMessage : AbstractMessage
{

public const uint Id = 5552;
public override uint MessageId
{
    get { return Id; }
}

public int recruterId;
        public string recruterName;
        public Types.BasicGuildInformations guildInfo;
        

public GuildInvitedMessage()
{
}

public GuildInvitedMessage(int recruterId, string recruterName, Types.BasicGuildInformations guildInfo)
        {
            this.recruterId = recruterId;
            this.recruterName = recruterName;
            this.guildInfo = guildInfo;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(recruterId);
            writer.WriteUTF(recruterName);
            guildInfo.Serialize(writer);
            

}

public override void Deserialize(IDataReader reader)
{

recruterId = reader.ReadInt();
            if (recruterId < 0)
                throw new Exception("Forbidden value on recruterId = " + recruterId + ", it doesn't respect the following condition : recruterId < 0");
            recruterName = reader.ReadUTF();
            guildInfo = new Types.BasicGuildInformations();
            guildInfo.Deserialize(reader);
            

}


}


}