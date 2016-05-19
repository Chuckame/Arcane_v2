


















// Generated on 05/16/2016 23:27:35
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class InventoryPresetItemUpdateRequestMessage : AbstractMessage
{

public const uint Id = 6210;
public override uint MessageId
{
    get { return Id; }
}

public sbyte presetId;
        public byte position;
        public int objUid;
        

public InventoryPresetItemUpdateRequestMessage()
{
}

public InventoryPresetItemUpdateRequestMessage(sbyte presetId, byte position, int objUid)
        {
            this.presetId = presetId;
            this.position = position;
            this.objUid = objUid;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteSByte(presetId);
            writer.WriteByte(position);
            writer.WriteInt(objUid);
            

}

public override void Deserialize(IDataReader reader)
{

presetId = reader.ReadSByte();
            if (presetId < 0)
                throw new Exception("Forbidden value on presetId = " + presetId + ", it doesn't respect the following condition : presetId < 0");
            position = reader.ReadByte();
            if (position < 0 || position > 255)
                throw new Exception("Forbidden value on position = " + position + ", it doesn't respect the following condition : position < 0 || position > 255");
            objUid = reader.ReadInt();
            if (objUid < 0)
                throw new Exception("Forbidden value on objUid = " + objUid + ", it doesn't respect the following condition : objUid < 0");
            

}


}


}