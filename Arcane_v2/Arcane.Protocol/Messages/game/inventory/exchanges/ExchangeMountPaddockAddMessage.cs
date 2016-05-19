


















// Generated on 05/16/2016 23:27:33
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class ExchangeMountPaddockAddMessage : AbstractMessage
{

public const uint Id = 6049;
public override uint MessageId
{
    get { return Id; }
}

public Types.MountClientData mountDescription;
        

public ExchangeMountPaddockAddMessage()
{
}

public ExchangeMountPaddockAddMessage(Types.MountClientData mountDescription)
        {
            this.mountDescription = mountDescription;
        }
        

public override void Serialize(IDataWriter writer)
{

mountDescription.Serialize(writer);
            

}

public override void Deserialize(IDataReader reader)
{

mountDescription = new Types.MountClientData();
            mountDescription.Deserialize(reader);
            

}


}


}