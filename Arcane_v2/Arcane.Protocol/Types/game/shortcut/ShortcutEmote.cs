


















// Generated on 05/16/2016 23:27:40
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class ShortcutEmote : Shortcut
{

public new const short Id = 389;
public override short TypeId { get { return Id; } }

public sbyte emoteId;
        

public ShortcutEmote()
{
}

public ShortcutEmote(int slot, sbyte emoteId)
         : base(slot)
        {
            this.emoteId = emoteId;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteSByte(emoteId);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            emoteId = reader.ReadSByte();
            if (emoteId < 0)
                throw new Exception("Forbidden value on emoteId = " + emoteId + ", it doesn't respect the following condition : emoteId < 0");
            

}


}


}