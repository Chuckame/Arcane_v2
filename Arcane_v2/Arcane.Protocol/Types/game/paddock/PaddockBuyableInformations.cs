


















// Generated on 05/16/2016 23:27:39
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class PaddockBuyableInformations : PaddockInformations
{

public new const short Id = 130;
public override short TypeId { get { return Id; } }

public int price;
        public bool locked;
        

public PaddockBuyableInformations()
{
}

public PaddockBuyableInformations(short maxOutdoorMount, short maxItems, int price, bool locked)
         : base(maxOutdoorMount, maxItems)
        {
            this.price = price;
            this.locked = locked;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteInt(price);
            writer.WriteBoolean(locked);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            price = reader.ReadInt();
            if (price < 0)
                throw new Exception("Forbidden value on price = " + price + ", it doesn't respect the following condition : price < 0");
            locked = reader.ReadBoolean();
            

}


}


}