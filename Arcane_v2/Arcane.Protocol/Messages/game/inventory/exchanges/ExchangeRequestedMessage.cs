


















// Generated on 05/16/2016 23:27:34
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class ExchangeRequestedMessage : AbstractMessage
{

public const uint Id = 5522;
public override uint MessageId
{
    get { return Id; }
}

public sbyte exchangeType;
        

public ExchangeRequestedMessage()
{
}

public ExchangeRequestedMessage(sbyte exchangeType)
        {
            this.exchangeType = exchangeType;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteSByte(exchangeType);
            

}

public override void Deserialize(IDataReader reader)
{

exchangeType = reader.ReadSByte();
            

}


}


}