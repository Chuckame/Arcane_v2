


















// Generated on 05/16/2016 23:27:28
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class HouseToSellListRequestMessage : AbstractMessage
{

public const uint Id = 6139;
public override uint MessageId
{
    get { return Id; }
}

public short pageIndex;
        

public HouseToSellListRequestMessage()
{
}

public HouseToSellListRequestMessage(short pageIndex)
        {
            this.pageIndex = pageIndex;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteShort(pageIndex);
            

}

public override void Deserialize(IDataReader reader)
{

pageIndex = reader.ReadShort();
            if (pageIndex < 0)
                throw new Exception("Forbidden value on pageIndex = " + pageIndex + ", it doesn't respect the following condition : pageIndex < 0");
            

}


}


}