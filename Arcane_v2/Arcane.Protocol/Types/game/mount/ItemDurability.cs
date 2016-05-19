


















// Generated on 05/16/2016 23:27:39
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class ItemDurability : AbstractType
{

public const short Id = 168;
public override short TypeId { get { return Id; } }

public short durability;
        public short durabilityMax;
        

public ItemDurability()
{
}

public ItemDurability(short durability, short durabilityMax)
        {
            this.durability = durability;
            this.durabilityMax = durabilityMax;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteShort(durability);
            writer.WriteShort(durabilityMax);
            

}

public override void Deserialize(IDataReader reader)
{

durability = reader.ReadShort();
            durabilityMax = reader.ReadShort();
            

}


}


}