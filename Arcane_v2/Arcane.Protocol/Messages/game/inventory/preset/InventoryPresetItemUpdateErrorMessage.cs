


















// Generated on 05/16/2016 23:27:35
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class InventoryPresetItemUpdateErrorMessage : AbstractMessage
{

public const uint Id = 6211;
public override uint MessageId
{
    get { return Id; }
}

public sbyte code;
        

public InventoryPresetItemUpdateErrorMessage()
{
}

public InventoryPresetItemUpdateErrorMessage(sbyte code)
        {
            this.code = code;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteSByte(code);
            

}

public override void Deserialize(IDataReader reader)
{

code = reader.ReadSByte();
            if (code < 0)
                throw new Exception("Forbidden value on code = " + code + ", it doesn't respect the following condition : code < 0");
            

}


}


}