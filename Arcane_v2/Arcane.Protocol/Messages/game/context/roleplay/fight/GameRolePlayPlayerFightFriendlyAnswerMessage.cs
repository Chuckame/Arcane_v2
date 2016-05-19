


















// Generated on 05/16/2016 23:27:27
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class GameRolePlayPlayerFightFriendlyAnswerMessage : AbstractMessage
{

public const uint Id = 5732;
public override uint MessageId
{
    get { return Id; }
}

public int fightId;
        public bool accept;
        

public GameRolePlayPlayerFightFriendlyAnswerMessage()
{
}

public GameRolePlayPlayerFightFriendlyAnswerMessage(int fightId, bool accept)
        {
            this.fightId = fightId;
            this.accept = accept;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(fightId);
            writer.WriteBoolean(accept);
            

}

public override void Deserialize(IDataReader reader)
{

fightId = reader.ReadInt();
            accept = reader.ReadBoolean();
            

}


}


}