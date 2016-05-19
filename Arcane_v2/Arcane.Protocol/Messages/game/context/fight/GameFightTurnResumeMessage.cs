


















// Generated on 05/16/2016 23:27:26
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class GameFightTurnResumeMessage : GameFightTurnStartMessage
{

public new const uint Id = 6307;
public override uint MessageId
{
    get { return Id; }
}



public GameFightTurnResumeMessage()
{
}

public GameFightTurnResumeMessage(int id, int waitTime)
         : base(id, waitTime)
        {
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            

}


}


}