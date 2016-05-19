


















// Generated on 05/16/2016 23:27:28
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class JobAllowMultiCraftRequestSetMessage : AbstractMessage
{

public const uint Id = 5749;
public override uint MessageId
{
    get { return Id; }
}

public bool enabled;
        

public JobAllowMultiCraftRequestSetMessage()
{
}

public JobAllowMultiCraftRequestSetMessage(bool enabled)
        {
            this.enabled = enabled;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteBoolean(enabled);
            

}

public override void Deserialize(IDataReader reader)
{

enabled = reader.ReadBoolean();
            

}


}


}