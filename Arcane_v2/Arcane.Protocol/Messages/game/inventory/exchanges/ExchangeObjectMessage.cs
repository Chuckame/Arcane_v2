


















// Generated on 05/16/2016 23:27:33
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class ExchangeObjectMessage : AbstractMessage
{

public const uint Id = 5515;
public override uint MessageId
{
    get { return Id; }
}

public bool remote;
        

public ExchangeObjectMessage()
{
}

public ExchangeObjectMessage(bool remote)
        {
            this.remote = remote;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteBoolean(remote);
            

}

public override void Deserialize(IDataReader reader)
{

remote = reader.ReadBoolean();
            

}


}


}