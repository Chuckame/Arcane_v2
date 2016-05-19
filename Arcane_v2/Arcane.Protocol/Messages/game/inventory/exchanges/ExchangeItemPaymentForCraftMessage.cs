


















// Generated on 05/16/2016 23:27:33
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class ExchangeItemPaymentForCraftMessage : AbstractMessage
{

public const uint Id = 5831;
public override uint MessageId
{
    get { return Id; }
}

public bool onlySuccess;
        public Types.ObjectItemNotInContainer @object;
        

public ExchangeItemPaymentForCraftMessage()
{
}

public ExchangeItemPaymentForCraftMessage(bool onlySuccess, Types.ObjectItemNotInContainer @object)
        {
            this.onlySuccess = onlySuccess;
            this.@object = @object;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteBoolean(onlySuccess);
            @object.Serialize(writer);
            

}

public override void Deserialize(IDataReader reader)
{

onlySuccess = reader.ReadBoolean();
            @object = new Types.ObjectItemNotInContainer();
            @object.Deserialize(reader);
            

}


}


}