


















// Generated on 05/16/2016 23:27:26
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class GameFightStartingMessage : AbstractMessage
{

public const uint Id = 700;
public override uint MessageId
{
    get { return Id; }
}

public sbyte fightType;
        

public GameFightStartingMessage()
{
}

public GameFightStartingMessage(sbyte fightType)
        {
            this.fightType = fightType;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteSByte(fightType);
            

}

public override void Deserialize(IDataReader reader)
{

fightType = reader.ReadSByte();
            if (fightType < 0)
                throw new Exception("Forbidden value on fightType = " + fightType + ", it doesn't respect the following condition : fightType < 0");
            

}


}


}