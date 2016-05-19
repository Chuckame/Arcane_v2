


















// Generated on 05/16/2016 23:27:22
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class AcquaintanceServerListMessage : AbstractMessage
{

public const uint Id = 6142;
public override uint MessageId
{
    get { return Id; }
}

public short[] servers;
        

public AcquaintanceServerListMessage()
{
}

public AcquaintanceServerListMessage(short[] servers)
        {
            this.servers = servers;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteUShort((ushort)servers.Length);
            foreach (var entry in servers)
            {
                 writer.WriteShort(entry);
            }
            

}

public override void Deserialize(IDataReader reader)
{

var limit = reader.ReadUShort();
            servers = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 servers[i] = reader.ReadShort();
            }
            

}


}


}