


















// Generated on 05/16/2016 23:27:26
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class MountRidingMessage : AbstractMessage
{

public const uint Id = 5967;
public override uint MessageId
{
    get { return Id; }
}

public bool isRiding;
        

public MountRidingMessage()
{
}

public MountRidingMessage(bool isRiding)
        {
            this.isRiding = isRiding;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteBoolean(isRiding);
            

}

public override void Deserialize(IDataReader reader)
{

isRiding = reader.ReadBoolean();
            

}


}


}