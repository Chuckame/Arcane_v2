


















// Generated on 05/16/2016 23:27:40
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class ShortcutSmiley : Shortcut
{

public new const short Id = 388;
public override short TypeId { get { return Id; } }

public sbyte smileyId;
        

public ShortcutSmiley()
{
}

public ShortcutSmiley(int slot, sbyte smileyId)
         : base(slot)
        {
            this.smileyId = smileyId;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteSByte(smileyId);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            smileyId = reader.ReadSByte();
            if (smileyId < 0)
                throw new Exception("Forbidden value on smileyId = " + smileyId + ", it doesn't respect the following condition : smileyId < 0");
            

}


}


}