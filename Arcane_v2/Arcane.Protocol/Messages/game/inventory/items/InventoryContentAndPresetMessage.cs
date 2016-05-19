


















// Generated on 05/16/2016 23:27:35
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class InventoryContentAndPresetMessage : InventoryContentMessage
{

public new const uint Id = 6162;
public override uint MessageId
{
    get { return Id; }
}

public Types.Preset[] presets;
        

public InventoryContentAndPresetMessage()
{
}

public InventoryContentAndPresetMessage(Types.ObjectItem[] objects, int kamas, Types.Preset[] presets)
         : base(objects, kamas)
        {
            this.presets = presets;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteUShort((ushort)presets.Length);
            foreach (var entry in presets)
            {
                 entry.Serialize(writer);
            }
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            var limit = reader.ReadUShort();
            presets = new Types.Preset[limit];
            for (int i = 0; i < limit; i++)
            {
                 presets[i] = new Types.Preset();
                 presets[i].Deserialize(reader);
            }
            

}


}


}