


















// Generated on 05/16/2016 23:27:22
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class ServerSelectionMessage : AbstractMessage
{

public const uint Id = 40;
public override uint MessageId
{
    get { return Id; }
}

public short serverId;
        

public ServerSelectionMessage()
{
}

public ServerSelectionMessage(short serverId)
        {
            this.serverId = serverId;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteShort(serverId);
            

}

public override void Deserialize(IDataReader reader)
{

serverId = reader.ReadShort();
            

}


}


}