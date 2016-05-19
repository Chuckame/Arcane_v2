


















// Generated on 05/16/2016 23:27:36
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class ShortcutBarAddErrorMessage : AbstractMessage
{

public const uint Id = 6227;
public override uint MessageId
{
    get { return Id; }
}

public sbyte error;
        

public ShortcutBarAddErrorMessage()
{
}

public ShortcutBarAddErrorMessage(sbyte error)
        {
            this.error = error;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteSByte(error);
            

}

public override void Deserialize(IDataReader reader)
{

error = reader.ReadSByte();
            if (error < 0)
                throw new Exception("Forbidden value on error = " + error + ", it doesn't respect the following condition : error < 0");
            

}


}


}