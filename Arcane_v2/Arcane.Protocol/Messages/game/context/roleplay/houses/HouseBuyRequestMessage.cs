


















// Generated on 05/16/2016 23:27:28
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class HouseBuyRequestMessage : AbstractMessage
{

public const uint Id = 5738;
public override uint MessageId
{
    get { return Id; }
}

public int proposedPrice;
        

public HouseBuyRequestMessage()
{
}

public HouseBuyRequestMessage(int proposedPrice)
        {
            this.proposedPrice = proposedPrice;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(proposedPrice);
            

}

public override void Deserialize(IDataReader reader)
{

proposedPrice = reader.ReadInt();
            if (proposedPrice < 0)
                throw new Exception("Forbidden value on proposedPrice = " + proposedPrice + ", it doesn't respect the following condition : proposedPrice < 0");
            

}


}


}