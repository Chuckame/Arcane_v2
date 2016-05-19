


















// Generated on 05/16/2016 23:27:32
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class ExchangeBidHouseItemRemoveOkMessage : AbstractMessage
{

public const uint Id = 5946;
public override uint MessageId
{
    get { return Id; }
}

public int sellerId;
        

public ExchangeBidHouseItemRemoveOkMessage()
{
}

public ExchangeBidHouseItemRemoveOkMessage(int sellerId)
        {
            this.sellerId = sellerId;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(sellerId);
            

}

public override void Deserialize(IDataReader reader)
{

sellerId = reader.ReadInt();
            

}


}


}