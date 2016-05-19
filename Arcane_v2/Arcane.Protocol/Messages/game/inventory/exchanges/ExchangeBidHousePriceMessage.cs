


















// Generated on 05/16/2016 23:27:32
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class ExchangeBidHousePriceMessage : AbstractMessage
{

public const uint Id = 5805;
public override uint MessageId
{
    get { return Id; }
}

public int genId;
        

public ExchangeBidHousePriceMessage()
{
}

public ExchangeBidHousePriceMessage(int genId)
        {
            this.genId = genId;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(genId);
            

}

public override void Deserialize(IDataReader reader)
{

genId = reader.ReadInt();
            if (genId < 0)
                throw new Exception("Forbidden value on genId = " + genId + ", it doesn't respect the following condition : genId < 0");
            

}


}


}