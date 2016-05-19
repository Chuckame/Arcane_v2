


















// Generated on 05/16/2016 23:27:40
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class Shortcut : AbstractType
{

public const short Id = 369;
public override short TypeId { get { return Id; } }

public int slot;
        

public Shortcut()
{
}

public Shortcut(int slot)
        {
            this.slot = slot;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(slot);
            

}

public override void Deserialize(IDataReader reader)
{

slot = reader.ReadInt();
            if (slot < 0 || slot > 99)
                throw new Exception("Forbidden value on slot = " + slot + ", it doesn't respect the following condition : slot < 0 || slot > 99");
            

}


}


}