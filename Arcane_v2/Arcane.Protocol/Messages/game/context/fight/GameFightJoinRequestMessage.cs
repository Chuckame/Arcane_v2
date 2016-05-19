


















// Generated on 05/16/2016 23:27:26
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class GameFightJoinRequestMessage : AbstractMessage
{

public const uint Id = 701;
public override uint MessageId
{
    get { return Id; }
}

public int fighterId;
        public int fightId;
        

public GameFightJoinRequestMessage()
{
}

public GameFightJoinRequestMessage(int fighterId, int fightId)
        {
            this.fighterId = fighterId;
            this.fightId = fightId;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(fighterId);
            writer.WriteInt(fightId);
            

}

public override void Deserialize(IDataReader reader)
{

fighterId = reader.ReadInt();
            fightId = reader.ReadInt();
            

}


}


}