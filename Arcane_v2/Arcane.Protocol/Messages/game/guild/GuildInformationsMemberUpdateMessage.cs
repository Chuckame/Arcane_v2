


















// Generated on 05/16/2016 23:27:31
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class GuildInformationsMemberUpdateMessage : AbstractMessage
{

public const uint Id = 5597;
public override uint MessageId
{
    get { return Id; }
}

public Types.GuildMember member;
        

public GuildInformationsMemberUpdateMessage()
{
}

public GuildInformationsMemberUpdateMessage(Types.GuildMember member)
        {
            this.member = member;
        }
        

public override void Serialize(IDataWriter writer)
{

member.Serialize(writer);
            

}

public override void Deserialize(IDataReader reader)
{

member = new Types.GuildMember();
            member.Deserialize(reader);
            

}


}


}