


















// Generated on 05/16/2016 23:27:26
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class GameFightTurnReadyRequestMessage : AbstractMessage
{

public const uint Id = 715;
public override uint MessageId
{
    get { return Id; }
}

public int id;
        

public GameFightTurnReadyRequestMessage()
{
}

public GameFightTurnReadyRequestMessage(int id)
        {
            this.id = id;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(id);
            

}

public override void Deserialize(IDataReader reader)
{

id = reader.ReadInt();
            

}


}


}