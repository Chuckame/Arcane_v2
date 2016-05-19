


















// Generated on 05/16/2016 23:27:34
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class ExchangeShopStockMultiMovementRemovedMessage : AbstractMessage
{

public const uint Id = 6037;
public override uint MessageId
{
    get { return Id; }
}

public int[] objectIdList;
        

public ExchangeShopStockMultiMovementRemovedMessage()
{
}

public ExchangeShopStockMultiMovementRemovedMessage(int[] objectIdList)
        {
            this.objectIdList = objectIdList;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteUShort((ushort)objectIdList.Length);
            foreach (var entry in objectIdList)
            {
                 writer.WriteInt(entry);
            }
            

}

public override void Deserialize(IDataReader reader)
{

var limit = reader.ReadUShort();
            objectIdList = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 objectIdList[i] = reader.ReadInt();
            }
            

}


}


}