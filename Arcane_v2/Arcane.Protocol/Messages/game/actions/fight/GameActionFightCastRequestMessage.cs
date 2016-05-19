


















// Generated on 05/16/2016 23:27:22
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class GameActionFightCastRequestMessage : AbstractMessage
{

public const uint Id = 1005;
public override uint MessageId
{
    get { return Id; }
}

public short spellId;
        public short cellId;
        

public GameActionFightCastRequestMessage()
{
}

public GameActionFightCastRequestMessage(short spellId, short cellId)
        {
            this.spellId = spellId;
            this.cellId = cellId;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteShort(spellId);
            writer.WriteShort(cellId);
            

}

public override void Deserialize(IDataReader reader)
{

spellId = reader.ReadShort();
            if (spellId < 0)
                throw new Exception("Forbidden value on spellId = " + spellId + ", it doesn't respect the following condition : spellId < 0");
            cellId = reader.ReadShort();
            if (cellId < -1 || cellId > 559)
                throw new Exception("Forbidden value on cellId = " + cellId + ", it doesn't respect the following condition : cellId < -1 || cellId > 559");
            

}


}


}