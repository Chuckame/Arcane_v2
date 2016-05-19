


















// Generated on 05/16/2016 23:27:26
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class GameFightPlacementPositionRequestMessage : AbstractMessage
{

public const uint Id = 704;
public override uint MessageId
{
    get { return Id; }
}

public short cellId;
        

public GameFightPlacementPositionRequestMessage()
{
}

public GameFightPlacementPositionRequestMessage(short cellId)
        {
            this.cellId = cellId;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteShort(cellId);
            

}

public override void Deserialize(IDataReader reader)
{

cellId = reader.ReadShort();
            if (cellId < 0 || cellId > 559)
                throw new Exception("Forbidden value on cellId = " + cellId + ", it doesn't respect the following condition : cellId < 0 || cellId > 559");
            

}


}


}