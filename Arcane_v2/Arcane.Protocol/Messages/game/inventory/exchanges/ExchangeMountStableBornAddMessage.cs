


















// Generated on 05/16/2016 23:27:33
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class ExchangeMountStableBornAddMessage : ExchangeMountStableAddMessage
{

public new const uint Id = 5966;
public override uint MessageId
{
    get { return Id; }
}



public ExchangeMountStableBornAddMessage()
{
}

public ExchangeMountStableBornAddMessage(Types.MountClientData mountDescription)
         : base(mountDescription)
        {
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            

}


}


}