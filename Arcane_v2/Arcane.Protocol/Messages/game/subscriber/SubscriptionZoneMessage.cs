


















// Generated on 05/16/2016 23:27:36
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class SubscriptionZoneMessage : AbstractMessage
{

public const uint Id = 5573;
public override uint MessageId
{
    get { return Id; }
}

public bool active;
        

public SubscriptionZoneMessage()
{
}

public SubscriptionZoneMessage(bool active)
        {
            this.active = active;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteBoolean(active);
            

}

public override void Deserialize(IDataReader reader)
{

active = reader.ReadBoolean();
            

}


}


}