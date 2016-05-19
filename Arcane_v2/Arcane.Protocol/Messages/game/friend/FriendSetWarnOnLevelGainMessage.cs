


















// Generated on 05/16/2016 23:27:31
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class FriendSetWarnOnLevelGainMessage : AbstractMessage
{

public const uint Id = 6077;
public override uint MessageId
{
    get { return Id; }
}

public bool enable;
        

public FriendSetWarnOnLevelGainMessage()
{
}

public FriendSetWarnOnLevelGainMessage(bool enable)
        {
            this.enable = enable;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteBoolean(enable);
            

}

public override void Deserialize(IDataReader reader)
{

enable = reader.ReadBoolean();
            

}


}


}