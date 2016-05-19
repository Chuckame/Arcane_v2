


















// Generated on 05/16/2016 23:27:27
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class MapRunningFightDetailsRequestMessage : AbstractMessage
{

public const uint Id = 5750;
public override uint MessageId
{
    get { return Id; }
}

public int fightId;
        

public MapRunningFightDetailsRequestMessage()
{
}

public MapRunningFightDetailsRequestMessage(int fightId)
        {
            this.fightId = fightId;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(fightId);
            

}

public override void Deserialize(IDataReader reader)
{

fightId = reader.ReadInt();
            if (fightId < 0)
                throw new Exception("Forbidden value on fightId = " + fightId + ", it doesn't respect the following condition : fightId < 0");
            

}


}


}