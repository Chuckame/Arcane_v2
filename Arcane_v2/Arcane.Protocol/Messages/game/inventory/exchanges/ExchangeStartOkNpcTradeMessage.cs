


















// Generated on 05/16/2016 23:27:34
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class ExchangeStartOkNpcTradeMessage : AbstractMessage
{

public const uint Id = 5785;
public override uint MessageId
{
    get { return Id; }
}

public int npcId;
        

public ExchangeStartOkNpcTradeMessage()
{
}

public ExchangeStartOkNpcTradeMessage(int npcId)
        {
            this.npcId = npcId;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(npcId);
            

}

public override void Deserialize(IDataReader reader)
{

npcId = reader.ReadInt();
            

}


}


}