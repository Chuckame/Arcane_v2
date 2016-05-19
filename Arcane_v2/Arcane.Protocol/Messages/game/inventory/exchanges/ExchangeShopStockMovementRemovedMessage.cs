


















// Generated on 05/16/2016 23:27:34
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class ExchangeShopStockMovementRemovedMessage : AbstractMessage
{

public const uint Id = 5907;
public override uint MessageId
{
    get { return Id; }
}

public int objectId;
        

public ExchangeShopStockMovementRemovedMessage()
{
}

public ExchangeShopStockMovementRemovedMessage(int objectId)
        {
            this.objectId = objectId;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(objectId);
            

}

public override void Deserialize(IDataReader reader)
{

objectId = reader.ReadInt();
            if (objectId < 0)
                throw new Exception("Forbidden value on objectId = " + objectId + ", it doesn't respect the following condition : objectId < 0");
            

}


}


}