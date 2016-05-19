


















// Generated on 05/16/2016 23:27:34
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class ExchangeWaitingResultMessage : AbstractMessage
{

public const uint Id = 5786;
public override uint MessageId
{
    get { return Id; }
}

public bool bwait;
        

public ExchangeWaitingResultMessage()
{
}

public ExchangeWaitingResultMessage(bool bwait)
        {
            this.bwait = bwait;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteBoolean(bwait);
            

}

public override void Deserialize(IDataReader reader)
{

bwait = reader.ReadBoolean();
            

}


}


}