


















// Generated on 05/16/2016 23:27:25
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class GameContextKickMessage : AbstractMessage
{

public const uint Id = 6081;
public override uint MessageId
{
    get { return Id; }
}

public int targetId;
        

public GameContextKickMessage()
{
}

public GameContextKickMessage(int targetId)
        {
            this.targetId = targetId;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(targetId);
            

}

public override void Deserialize(IDataReader reader)
{

targetId = reader.ReadInt();
            

}


}


}