


















// Generated on 05/16/2016 23:27:28
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class HouseToSellListMessage : AbstractMessage
{

public const uint Id = 6140;
public override uint MessageId
{
    get { return Id; }
}

public short pageIndex;
        public short totalPage;
        public Types.HouseInformationsForSell[] houseList;
        

public HouseToSellListMessage()
{
}

public HouseToSellListMessage(short pageIndex, short totalPage, Types.HouseInformationsForSell[] houseList)
        {
            this.pageIndex = pageIndex;
            this.totalPage = totalPage;
            this.houseList = houseList;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteShort(pageIndex);
            writer.WriteShort(totalPage);
            writer.WriteUShort((ushort)houseList.Length);
            foreach (var entry in houseList)
            {
                 entry.Serialize(writer);
            }
            

}

public override void Deserialize(IDataReader reader)
{

pageIndex = reader.ReadShort();
            if (pageIndex < 0)
                throw new Exception("Forbidden value on pageIndex = " + pageIndex + ", it doesn't respect the following condition : pageIndex < 0");
            totalPage = reader.ReadShort();
            if (totalPage < 0)
                throw new Exception("Forbidden value on totalPage = " + totalPage + ", it doesn't respect the following condition : totalPage < 0");
            var limit = reader.ReadUShort();
            houseList = new Types.HouseInformationsForSell[limit];
            for (int i = 0; i < limit; i++)
            {
                 houseList[i] = new Types.HouseInformationsForSell();
                 houseList[i].Deserialize(reader);
            }
            

}


}


}