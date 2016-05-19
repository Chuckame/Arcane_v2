


















// Generated on 05/16/2016 23:27:40
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class ShortcutObject : Shortcut
{

public new const short Id = 367;
public override short TypeId { get { return Id; } }



public ShortcutObject()
{
}

public ShortcutObject(int slot)
         : base(slot)
        {
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            

}


}


}