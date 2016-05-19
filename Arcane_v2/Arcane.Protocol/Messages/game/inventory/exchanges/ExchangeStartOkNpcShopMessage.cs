


















// Generated on 05/16/2016 23:27:34
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class ExchangeStartOkNpcShopMessage : AbstractMessage
{

public const uint Id = 5761;
public override uint MessageId
{
    get { return Id; }
}

public int npcSellerId;
        public int tokenId;
        public Types.ObjectItemToSellInNpcShop[] objectsInfos;
        

public ExchangeStartOkNpcShopMessage()
{
}

public ExchangeStartOkNpcShopMessage(int npcSellerId, int tokenId, Types.ObjectItemToSellInNpcShop[] objectsInfos)
        {
            this.npcSellerId = npcSellerId;
            this.tokenId = tokenId;
            this.objectsInfos = objectsInfos;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(npcSellerId);
            writer.WriteInt(tokenId);
            writer.WriteUShort((ushort)objectsInfos.Length);
            foreach (var entry in objectsInfos)
            {
                 entry.Serialize(writer);
            }
            

}

public override void Deserialize(IDataReader reader)
{

npcSellerId = reader.ReadInt();
            tokenId = reader.ReadInt();
            if (tokenId < 0)
                throw new Exception("Forbidden value on tokenId = " + tokenId + ", it doesn't respect the following condition : tokenId < 0");
            var limit = reader.ReadUShort();
            objectsInfos = new Types.ObjectItemToSellInNpcShop[limit];
            for (int i = 0; i < limit; i++)
            {
                 objectsInfos[i] = new Types.ObjectItemToSellInNpcShop();
                 objectsInfos[i].Deserialize(reader);
            }
            

}


}


}