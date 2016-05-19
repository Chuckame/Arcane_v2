


















// Generated on 05/16/2016 23:27:26
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class GameFightUpdateTeamMessage : AbstractMessage
{

public const uint Id = 5572;
public override uint MessageId
{
    get { return Id; }
}

public short fightId;
        public Types.FightTeamInformations team;
        

public GameFightUpdateTeamMessage()
{
}

public GameFightUpdateTeamMessage(short fightId, Types.FightTeamInformations team)
        {
            this.fightId = fightId;
            this.team = team;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteShort(fightId);
            team.Serialize(writer);
            

}

public override void Deserialize(IDataReader reader)
{

fightId = reader.ReadShort();
            if (fightId < 0)
                throw new Exception("Forbidden value on fightId = " + fightId + ", it doesn't respect the following condition : fightId < 0");
            team = new Types.FightTeamInformations();
            team.Deserialize(reader);
            

}


}


}