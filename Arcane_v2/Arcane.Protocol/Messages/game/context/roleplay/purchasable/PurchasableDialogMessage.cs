


















// Generated on 05/16/2016 23:27:30
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class PurchasableDialogMessage : AbstractMessage
{

public const uint Id = 5739;
public override uint MessageId
{
    get { return Id; }
}

public bool buyOrSell;
        public int purchasableId;
        public int price;
        

public PurchasableDialogMessage()
{
}

public PurchasableDialogMessage(bool buyOrSell, int purchasableId, int price)
        {
            this.buyOrSell = buyOrSell;
            this.purchasableId = purchasableId;
            this.price = price;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteBoolean(buyOrSell);
            writer.WriteInt(purchasableId);
            writer.WriteInt(price);
            

}

public override void Deserialize(IDataReader reader)
{

buyOrSell = reader.ReadBoolean();
            purchasableId = reader.ReadInt();
            if (purchasableId < 0)
                throw new Exception("Forbidden value on purchasableId = " + purchasableId + ", it doesn't respect the following condition : purchasableId < 0");
            price = reader.ReadInt();
            if (price < 0)
                throw new Exception("Forbidden value on price = " + price + ", it doesn't respect the following condition : price < 0");
            

}


}


}