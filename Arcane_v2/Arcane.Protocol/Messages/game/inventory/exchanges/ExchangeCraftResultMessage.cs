


















// Generated on 05/16/2016 23:27:33
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class ExchangeCraftResultMessage : AbstractMessage
{

public const uint Id = 5790;
public override uint MessageId
{
    get { return Id; }
}

public sbyte craftResult;
        

public ExchangeCraftResultMessage()
{
}

public ExchangeCraftResultMessage(sbyte craftResult)
        {
            this.craftResult = craftResult;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteSByte(craftResult);
            

}

public override void Deserialize(IDataReader reader)
{

craftResult = reader.ReadSByte();
            if (craftResult < 0)
                throw new Exception("Forbidden value on craftResult = " + craftResult + ", it doesn't respect the following condition : craftResult < 0");
            

}


}


}