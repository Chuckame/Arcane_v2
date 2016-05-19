


















// Generated on 05/16/2016 23:27:24
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class CharacterReplayRequestMessage : AbstractMessage
{

public const uint Id = 167;
public override uint MessageId
{
    get { return Id; }
}

public int characterId;
        

public CharacterReplayRequestMessage()
{
}

public CharacterReplayRequestMessage(int characterId)
        {
            this.characterId = characterId;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(characterId);
            

}

public override void Deserialize(IDataReader reader)
{

characterId = reader.ReadInt();
            if (characterId < 0)
                throw new Exception("Forbidden value on characterId = " + characterId + ", it doesn't respect the following condition : characterId < 0");
            

}


}


}