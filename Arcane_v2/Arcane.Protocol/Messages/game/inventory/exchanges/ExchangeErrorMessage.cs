


















// Generated on 05/16/2016 23:27:33
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class ExchangeErrorMessage : AbstractMessage
{

public const uint Id = 5513;
public override uint MessageId
{
    get { return Id; }
}

public sbyte errorType;
        

public ExchangeErrorMessage()
{
}

public ExchangeErrorMessage(sbyte errorType)
        {
            this.errorType = errorType;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteSByte(errorType);
            

}

public override void Deserialize(IDataReader reader)
{

errorType = reader.ReadSByte();
            

}


}


}