


















// Generated on 05/16/2016 23:27:35
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class ObjectModifiedMessage : AbstractMessage
{

public const uint Id = 3029;
public override uint MessageId
{
    get { return Id; }
}

public Types.ObjectItem @object;
        

public ObjectModifiedMessage()
{
}

public ObjectModifiedMessage(Types.ObjectItem @object)
        {
            this.@object = @object;
        }
        

public override void Serialize(IDataWriter writer)
{

@object.Serialize(writer);
            

}

public override void Deserialize(IDataReader reader)
{

@object = new Types.ObjectItem();
            @object.Deserialize(reader);
            

}


}


}