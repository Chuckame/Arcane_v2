


















// Generated on 05/16/2016 23:27:26
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class GameFightOptionStateUpdateMessage : AbstractMessage
{

public const uint Id = 5927;
public override uint MessageId
{
    get { return Id; }
}

public short fightId;
        public sbyte teamId;
        public sbyte option;
        public bool state;
        

public GameFightOptionStateUpdateMessage()
{
}

public GameFightOptionStateUpdateMessage(short fightId, sbyte teamId, sbyte option, bool state)
        {
            this.fightId = fightId;
            this.teamId = teamId;
            this.option = option;
            this.state = state;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteShort(fightId);
            writer.WriteSByte(teamId);
            writer.WriteSByte(option);
            writer.WriteBoolean(state);
            

}

public override void Deserialize(IDataReader reader)
{

fightId = reader.ReadShort();
            if (fightId < 0)
                throw new Exception("Forbidden value on fightId = " + fightId + ", it doesn't respect the following condition : fightId < 0");
            teamId = reader.ReadSByte();
            if (teamId < 0)
                throw new Exception("Forbidden value on teamId = " + teamId + ", it doesn't respect the following condition : teamId < 0");
            option = reader.ReadSByte();
            if (option < 0)
                throw new Exception("Forbidden value on option = " + option + ", it doesn't respect the following condition : option < 0");
            state = reader.ReadBoolean();
            

}


}


}