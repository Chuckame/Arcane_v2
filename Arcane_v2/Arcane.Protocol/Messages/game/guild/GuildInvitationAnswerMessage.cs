


















// Generated on 05/16/2016 23:27:31
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class GuildInvitationAnswerMessage : AbstractMessage
{

public const uint Id = 5556;
public override uint MessageId
{
    get { return Id; }
}

public bool accept;
        

public GuildInvitationAnswerMessage()
{
}

public GuildInvitationAnswerMessage(bool accept)
        {
            this.accept = accept;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteBoolean(accept);
            

}

public override void Deserialize(IDataReader reader)
{

accept = reader.ReadBoolean();
            

}


}


}