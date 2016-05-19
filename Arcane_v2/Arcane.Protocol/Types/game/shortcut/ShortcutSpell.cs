


















// Generated on 05/16/2016 23:27:40
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class ShortcutSpell : Shortcut
{

public new const short Id = 368;
public override short TypeId { get { return Id; } }

public short spellId;
        

public ShortcutSpell()
{
}

public ShortcutSpell(int slot, short spellId)
         : base(slot)
        {
            this.spellId = spellId;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteShort(spellId);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            spellId = reader.ReadShort();
            if (spellId < 0)
                throw new Exception("Forbidden value on spellId = " + spellId + ", it doesn't respect the following condition : spellId < 0");
            

}


}


}