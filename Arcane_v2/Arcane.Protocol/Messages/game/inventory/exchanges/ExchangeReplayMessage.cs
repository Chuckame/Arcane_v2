


















// Generated on 05/16/2016 23:27:34
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class ExchangeReplayMessage : AbstractMessage
{

public const uint Id = 6002;
public override uint MessageId
{
    get { return Id; }
}

public int count;
        

public ExchangeReplayMessage()
{
}

public ExchangeReplayMessage(int count)
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
            

}


}


}