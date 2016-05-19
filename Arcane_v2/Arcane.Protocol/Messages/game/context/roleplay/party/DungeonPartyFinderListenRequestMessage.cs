


















// Generated on 05/16/2016 23:27:29
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class DungeonPartyFinderListenRequestMessage : AbstractMessage
{

public const uint Id = 6246;
public override uint MessageId
{
    get { return Id; }
}

public short dungeonId;
        

public DungeonPartyFinderListenRequestMessage()
{
}

public DungeonPartyFinderListenRequestMessage(short dungeonId)
        {
            this.dungeonId = dungeonId;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteShort(dungeonId);
            

}

public override void Deserialize(IDataReader reader)
{

dungeonId = reader.ReadShort();
            if (dungeonId < 0)
                throw new Exception("Forbidden value on dungeonId = " + dungeonId + ", it doesn't respect the following condition : dungeonId < 0");
            

}


}


}