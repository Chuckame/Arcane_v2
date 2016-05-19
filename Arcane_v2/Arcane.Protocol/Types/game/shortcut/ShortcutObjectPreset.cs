


















// Generated on 05/16/2016 23:27:40
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class ShortcutObjectPreset : ShortcutObject
{

public new const short Id = 370;
public override short TypeId { get { return Id; } }

public sbyte presetId;
        

public ShortcutObjectPreset()
{
}

public ShortcutObjectPreset(int slot, sbyte presetId)
         : base(slot)
        {
            this.presetId = presetId;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteSByte(presetId);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            presetId = reader.ReadSByte();
            if (presetId < 0)
                throw new Exception("Forbidden value on presetId = " + presetId + ", it doesn't respect the following condition : presetId < 0");
            

}


}


}