


















// Generated on 05/16/2016 23:27:26
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class DungeonKeyRingUpdateMessage : AbstractMessage
{

public const uint Id = 6296;
public override uint MessageId
{
    get { return Id; }
}

public short dungeonId;
        public bool available;
        

public DungeonKeyRingUpdateMessage()
{
}

public DungeonKeyRingUpdateMessage(short dungeonId, bool available)
        {
            this.dungeonId = dungeonId;
            this.available = available;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteShort(dungeonId);
            writer.WriteBoolean(available);
            

}

public override void Deserialize(IDataReader reader)
{

dungeonId = reader.ReadShort();
            if (dungeonId < 0)
                throw new Exception("Forbidden value on dungeonId = " + dungeonId + ", it doesn't respect the following condition : dungeonId < 0");
            available = reader.ReadBoolean();
            

}


}


}