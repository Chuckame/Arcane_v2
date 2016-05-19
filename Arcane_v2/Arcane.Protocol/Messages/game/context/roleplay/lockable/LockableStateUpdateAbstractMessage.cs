


















// Generated on 05/16/2016 23:27:28
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class LockableStateUpdateAbstractMessage : AbstractMessage
{

public const uint Id = 5671;
public override uint MessageId
{
    get { return Id; }
}

public bool locked;
        

public LockableStateUpdateAbstractMessage()
{
}

public LockableStateUpdateAbstractMessage(bool locked)
        {
            this.locked = locked;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteBoolean(locked);
            

}

public override void Deserialize(IDataReader reader)
{

locked = reader.ReadBoolean();
            

}


}


}