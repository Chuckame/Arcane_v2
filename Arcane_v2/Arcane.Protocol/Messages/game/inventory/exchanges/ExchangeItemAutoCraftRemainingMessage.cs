


















// Generated on 05/16/2016 23:27:33
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class ExchangeItemAutoCraftRemainingMessage : AbstractMessage
{

public const uint Id = 6015;
public override uint MessageId
{
    get { return Id; }
}

public int count;
        

public ExchangeItemAutoCraftRemainingMessage()
{
}

public ExchangeItemAutoCraftRemainingMessage(int count)
        {
            this.count = count;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(count);
            

}

public override void Deserialize(IDataReader reader)
{

count = reader.ReadInt();
            if (count < 0)
                throw new Exception("Forbidden value on count = " + count + ", it doesn't respect the following condition : count < 0");
            

}


}


}