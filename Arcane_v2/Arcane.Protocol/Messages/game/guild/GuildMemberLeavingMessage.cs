


















// Generated on 05/16/2016 23:27:31
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class GuildMemberLeavingMessage : AbstractMessage
{

public const uint Id = 5923;
public override uint MessageId
{
    get { return Id; }
}

public bool kicked;
        public int memberId;
        

public GuildMemberLeavingMessage()
{
}

public GuildMemberLeavingMessage(bool kicked, int memberId)
        {
            this.kicked = kicked;
            this.memberId = memberId;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteBoolean(kicked);
            writer.WriteInt(memberId);
            

}

public override void Deserialize(IDataReader reader)
{

kicked = reader.ReadBoolean();
            memberId = reader.ReadInt();
            

}


}


}