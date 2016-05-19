


















// Generated on 05/16/2016 23:27:31
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class GuildHouseRemoveMessage : AbstractMessage
{

public const uint Id = 6180;
public override uint MessageId
{
    get { return Id; }
}

public int houseId;
        

public GuildHouseRemoveMessage()
{
}

public GuildHouseRemoveMessage(int houseId)
        {
            this.houseId = houseId;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(houseId);
            

}

public override void Deserialize(IDataReader reader)
{

houseId = reader.ReadInt();
            if (houseId < 0)
                throw new Exception("Forbidden value on houseId = " + houseId + ", it doesn't respect the following condition : houseId < 0");
            

}


}


}