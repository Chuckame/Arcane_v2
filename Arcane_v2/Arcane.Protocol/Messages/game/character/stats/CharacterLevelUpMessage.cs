


















// Generated on 05/16/2016 23:27:24
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class CharacterLevelUpMessage : AbstractMessage
{

public const uint Id = 5670;
public override uint MessageId
{
    get { return Id; }
}

public byte newLevel;
        

public CharacterLevelUpMessage()
{
}

public CharacterLevelUpMessage(byte newLevel)
        {
            this.newLevel = newLevel;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteByte(newLevel);
            

}

public override void Deserialize(IDataReader reader)
{

newLevel = reader.ReadByte();
            if (newLevel < 2 || newLevel > 200)
                throw new Exception("Forbidden value on newLevel = " + newLevel + ", it doesn't respect the following condition : newLevel < 2 || newLevel > 200");
            

}


}


}