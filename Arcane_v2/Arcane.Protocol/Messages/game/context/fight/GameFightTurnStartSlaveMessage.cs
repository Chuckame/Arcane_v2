


















// Generated on 05/16/2016 23:27:26
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class GameFightTurnStartSlaveMessage : GameFightTurnStartMessage
{

public new const uint Id = 6213;
public override uint MessageId
{
    get { return Id; }
}

public int idSummoner;
        

public GameFightTurnStartSlaveMessage()
{
}

public GameFightTurnStartSlaveMessage(int id, int waitTime, int idSummoner)
         : base(id, waitTime)
        {
            this.idSummoner = idSummoner;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteInt(idSummoner);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            idSummoner = reader.ReadInt();
            

}


}


}