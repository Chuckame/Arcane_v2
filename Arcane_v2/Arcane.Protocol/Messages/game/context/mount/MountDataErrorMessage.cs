


















// Generated on 05/16/2016 23:27:26
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class MountDataErrorMessage : AbstractMessage
{

public const uint Id = 6172;
public override uint MessageId
{
    get { return Id; }
}

public sbyte reason;
        

public MountDataErrorMessage()
{
}

public MountDataErrorMessage(sbyte reason)
        {
            this.reason = reason;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteSByte(reason);
            

}

public override void Deserialize(IDataReader reader)
{

reason = reader.ReadSByte();
            if (reason < 0)
                throw new Exception("Forbidden value on reason = " + reason + ", it doesn't respect the following condition : reason < 0");
            

}


}


}