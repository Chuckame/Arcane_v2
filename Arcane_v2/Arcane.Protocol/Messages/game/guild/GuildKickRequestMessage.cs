


















// Generated on 05/16/2016 23:27:31
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class GuildKickRequestMessage : AbstractMessage
{

public const uint Id = 5887;
public override uint MessageId
{
    get { return Id; }
}

public int kickedId;
        

public GuildKickRequestMessage()
{
}

public GuildKickRequestMessage(int kickedId)
        {
            this.kickedId = kickedId;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(kickedId);
            

}

public override void Deserialize(IDataReader reader)
{

kickedId = reader.ReadInt();
            if (kickedId < 0)
                throw new Exception("Forbidden value on kickedId = " + kickedId + ", it doesn't respect the following condition : kickedId < 0");
            

}


}


}