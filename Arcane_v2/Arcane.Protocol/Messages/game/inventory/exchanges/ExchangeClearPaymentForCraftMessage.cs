


















// Generated on 05/16/2016 23:27:33
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class ExchangeClearPaymentForCraftMessage : AbstractMessage
{

public const uint Id = 6145;
public override uint MessageId
{
    get { return Id; }
}

public sbyte paymentType;
        

public ExchangeClearPaymentForCraftMessage()
{
}

public ExchangeClearPaymentForCraftMessage(sbyte paymentType)
        {
            this.paymentType = paymentType;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteSByte(paymentType);
            

}

public override void Deserialize(IDataReader reader)
{

paymentType = reader.ReadSByte();
            

}


}


}