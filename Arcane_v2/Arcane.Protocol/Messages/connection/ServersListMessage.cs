


















// Generated on 05/16/2016 23:27:22
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class ServersListMessage : AbstractMessage
{

public const uint Id = 30;
public override uint MessageId
{
    get { return Id; }
}

public Types.GameServerInformations[] servers;
        

public ServersListMessage()
{
}

public ServersListMessage(Types.GameServerInformations[] servers)
        {
            this.servers = servers;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteUShort((ushort)servers.Length);
            foreach (var entry in servers)
            {
                 entry.Serialize(writer);
            }
            

}

public override void Deserialize(IDataReader reader)
{

var limit = reader.ReadUShort();
            servers = new Types.GameServerInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 servers[i] = new Types.GameServerInformations();
                 servers[i].Deserialize(reader);
            }
            

}


}


}