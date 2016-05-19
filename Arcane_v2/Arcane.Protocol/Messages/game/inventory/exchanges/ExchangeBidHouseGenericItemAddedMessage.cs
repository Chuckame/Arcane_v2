


















// Generated on 05/16/2016 23:27:32
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class ExchangeBidHouseGenericItemAddedMessage : AbstractMessage
{

public const uint Id = 5947;
public override uint MessageId
{
    get { return Id; }
}

public int objGenericId;
        

public ExchangeBidHouseGenericItemAddedMessage()
{
}

public ExchangeBidHouseGenericItemAddedMessage(int objGenericId)
        {
            this.objGenericId = objGenericId;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(objGenericId);
            

}

public override void Deserialize(IDataReader reader)
{

objGenericId = reader.ReadInt();
            

}


}


}