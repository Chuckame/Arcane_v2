


















// Generated on 05/16/2016 23:27:35
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class InventoryPresetDeleteMessage : AbstractMessage
{

public const uint Id = 6169;
public override uint MessageId
{
    get { return Id; }
}

public sbyte presetId;
        

public InventoryPresetDeleteMessage()
{
}

public InventoryPresetDeleteMessage(sbyte presetId)
        {
            this.presetId = presetId;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteSByte(presetId);
            

}

public override void Deserialize(IDataReader reader)
{

presetId = reader.ReadSByte();
            if (presetId < 0)
                throw new Exception("Forbidden value on presetId = " + presetId + ", it doesn't respect the following condition : presetId < 0");
            

}


}


}