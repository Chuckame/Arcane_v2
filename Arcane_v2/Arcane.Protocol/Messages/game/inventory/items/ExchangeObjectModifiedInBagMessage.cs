


















// Generated on 05/16/2016 23:27:34
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class ExchangeObjectModifiedInBagMessage : ExchangeObjectMessage
{

public new const uint Id = 6008;
public override uint MessageId
{
    get { return Id; }
}

public Types.ObjectItem @object;
        

public ExchangeObjectModifiedInBagMessage()
{
}

public ExchangeObjectModifiedInBagMessage(bool remote, Types.ObjectItem @object)
         : base(remote)
        {
            this.@object = @object;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            @object.Serialize(writer);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            @object = new Types.ObjectItem();
            @object.Deserialize(reader);
            

}


}


}