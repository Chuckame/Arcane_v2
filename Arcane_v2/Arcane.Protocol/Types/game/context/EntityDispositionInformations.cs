


















// Generated on 05/16/2016 23:27:37
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class EntityDispositionInformations : AbstractType
{

public const short Id = 60;
public override short TypeId { get { return Id; } }

public short cellId;
        public sbyte direction;
        

public EntityDispositionInformations()
{
}

public EntityDispositionInformations(short cellId, sbyte direction)
        {
            this.cellId = cellId;
            this.direction = direction;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteShort(cellId);
            writer.WriteSByte(direction);
            

}

public override void Deserialize(IDataReader reader)
{

cellId = reader.ReadShort();
            if (cellId < -1 || cellId > 559)
                throw new Exception("Forbidden value on cellId = " + cellId + ", it doesn't respect the following condition : cellId < -1 || cellId > 559");
            direction = reader.ReadSByte();
            if (direction < 0)
                throw new Exception("Forbidden value on direction = " + direction + ", it doesn't respect the following condition : direction < 0");
            

}


}


}