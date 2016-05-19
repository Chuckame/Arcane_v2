


















// Generated on 05/16/2016 23:27:32
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class ExchangeBidHouseInListRemovedMessage : AbstractMessage
{

public const uint Id = 5950;
public override uint MessageId
{
    get { return Id; }
}

public int itemUID;
        

public ExchangeBidHouseInListRemovedMessage()
{
}

public ExchangeBidHouseInListRemovedMessage(int itemUID)
        {
            this.itemUID = itemUID;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(itemUID);
            

}

public override void Deserialize(IDataReader reader)
{

itemUID = reader.ReadInt();
            

}


}


}