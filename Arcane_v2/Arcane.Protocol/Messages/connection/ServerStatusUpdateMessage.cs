


















// Generated on 05/16/2016 23:27:22
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class ServerStatusUpdateMessage : AbstractMessage
{

public const uint Id = 50;
public override uint MessageId
{
    get { return Id; }
}

public Types.GameServerInformations server;
        

public ServerStatusUpdateMessage()
{
}

public ServerStatusUpdateMessage(Types.GameServerInformations server)
        {
            this.server = server;
        }
        

public override void Serialize(IDataWriter writer)
{

server.Serialize(writer);
            

}

public override void Deserialize(IDataReader reader)
{

server = new Types.GameServerInformations();
            server.Deserialize(reader);
            

}


}


}