


















// Generated on 05/16/2016 23:27:26
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class GameFightLeaveMessage : AbstractMessage
{

public const uint Id = 721;
public override uint MessageId
{
    get { return Id; }
}

public int charId;
        

public GameFightLeaveMessage()
{
}

public GameFightLeaveMessage(int charId)
        {
            this.charId = charId;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(charId);
            

}

public override void Deserialize(IDataReader reader)
{

charId = reader.ReadInt();
            

}


}


}