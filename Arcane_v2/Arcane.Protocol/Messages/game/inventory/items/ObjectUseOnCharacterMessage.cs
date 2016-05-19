


















// Generated on 05/16/2016 23:27:35
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class ObjectUseOnCharacterMessage : ObjectUseMessage
{

public new const uint Id = 3003;
public override uint MessageId
{
    get { return Id; }
}

public int characterId;
        

public ObjectUseOnCharacterMessage()
{
}

public ObjectUseOnCharacterMessage(int objectUID, int characterId)
         : base(objectUID)
        {
            this.characterId = characterId;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteInt(characterId);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            characterId = reader.ReadInt();
            if (characterId < 0)
                throw new Exception("Forbidden value on characterId = " + characterId + ", it doesn't respect the following condition : characterId < 0");
            

}


}


}