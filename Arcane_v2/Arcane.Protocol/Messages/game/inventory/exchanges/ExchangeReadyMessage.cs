


















// Generated on 05/16/2016 23:27:33
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class ExchangeReadyMessage : AbstractMessage
{

public const uint Id = 5511;
public override uint MessageId
{
    get { return Id; }
}

public bool ready;
        

public ExchangeReadyMessage()
{
}

public ExchangeReadyMessage(bool ready)
        {
            this.ready = ready;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteBoolean(ready);
            

}

public override void Deserialize(IDataReader reader)
{

ready = reader.ReadBoolean();
            

}


}


}