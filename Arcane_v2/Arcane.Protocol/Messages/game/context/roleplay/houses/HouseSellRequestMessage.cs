


















// Generated on 05/16/2016 23:27:28
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class HouseSellRequestMessage : AbstractMessage
{

public const uint Id = 5697;
public override uint MessageId
{
    get { return Id; }
}

public int amount;
        

public HouseSellRequestMessage()
{
}

public HouseSellRequestMessage(int amount)
        {
            this.amount = amount;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(amount);
            

}

public override void Deserialize(IDataReader reader)
{

amount = reader.ReadInt();
            if (amount < 0)
                throw new Exception("Forbidden value on amount = " + amount + ", it doesn't respect the following condition : amount < 0");
            

}


}


}