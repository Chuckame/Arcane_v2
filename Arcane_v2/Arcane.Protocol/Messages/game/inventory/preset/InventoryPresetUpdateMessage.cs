


















// Generated on 05/16/2016 23:27:35
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class InventoryPresetUpdateMessage : AbstractMessage
{

public const uint Id = 6171;
public override uint MessageId
{
    get { return Id; }
}

public Types.Preset preset;
        

public InventoryPresetUpdateMessage()
{
}

public InventoryPresetUpdateMessage(Types.Preset preset)
        {
            this.preset = preset;
        }
        

public override void Serialize(IDataWriter writer)
{

preset.Serialize(writer);
            

}

public override void Deserialize(IDataReader reader)
{

preset = new Types.Preset();
            preset.Deserialize(reader);
            

}


}


}