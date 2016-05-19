


















// Generated on 05/16/2016 23:27:27
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class TeleportOnSameMapMessage : AbstractMessage
{

public const uint Id = 6048;
public override uint MessageId
{
    get { return Id; }
}

public int targetId;
        public short cellId;
        

public TeleportOnSameMapMessage()
{
}

public TeleportOnSameMapMessage(int targetId, short cellId)
        {
            this.targetId = targetId;
            this.cellId = cellId;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(targetId);
            writer.WriteShort(cellId);
            

}

public override void Deserialize(IDataReader reader)
{

targetId = reader.ReadInt();
            cellId = reader.ReadShort();
            if (cellId < 0 || cellId > 559)
                throw new Exception("Forbidden value on cellId = " + cellId + ", it doesn't respect the following condition : cellId < 0 || cellId > 559");
            

}


}


}