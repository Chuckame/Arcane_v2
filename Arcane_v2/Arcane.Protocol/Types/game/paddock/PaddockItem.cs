


















// Generated on 05/16/2016 23:27:39
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class PaddockItem : ObjectItemInRolePlay
{

public new const short Id = 185;
public override short TypeId { get { return Id; } }

public Types.ItemDurability durability;
        

public PaddockItem()
{
}

public PaddockItem(short cellId, short objectGID, Types.ItemDurability durability)
         : base(cellId, objectGID)
        {
            this.durability = durability;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            durability.Serialize(writer);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            durability = new Types.ItemDurability();
            durability.Deserialize(reader);
            

}


}


}