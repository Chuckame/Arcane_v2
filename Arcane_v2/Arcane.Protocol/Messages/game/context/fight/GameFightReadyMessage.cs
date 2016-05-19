


















// Generated on 05/16/2016 23:27:26
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class GameFightReadyMessage : AbstractMessage
{

public const uint Id = 708;
public override uint MessageId
{
    get { return Id; }
}

public bool isReady;
        

public GameFightReadyMessage()
{
}

public GameFightReadyMessage(bool isReady)
        {
            this.isReady = isReady;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteBoolean(isReady);
            

}

public override void Deserialize(IDataReader reader)
{

isReady = reader.ReadBoolean();
            

}


}


}