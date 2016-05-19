


















// Generated on 05/16/2016 23:27:28
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class HouseSoldMessage : AbstractMessage
{

public const uint Id = 5737;
public override uint MessageId
{
    get { return Id; }
}

public int houseId;
        public int realPrice;
        public string buyerName;
        

public HouseSoldMessage()
{
}

public HouseSoldMessage(int houseId, int realPrice, string buyerName)
        {
            this.houseId = houseId;
            this.realPrice = realPrice;
            this.buyerName = buyerName;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(houseId);
            writer.WriteInt(realPrice);
            writer.WriteUTF(buyerName);
            

}

public override void Deserialize(IDataReader reader)
{

houseId = reader.ReadInt();
            if (houseId < 0)
                throw new Exception("Forbidden value on houseId = " + houseId + ", it doesn't respect the following condition : houseId < 0");
            realPrice = reader.ReadInt();
            if (realPrice < 0)
                throw new Exception("Forbidden value on realPrice = " + realPrice + ", it doesn't respect the following condition : realPrice < 0");
            buyerName = reader.ReadUTF();
            

}


}


}