


















// Generated on 05/16/2016 23:27:24
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class CharacterNameSuggestionSuccessMessage : AbstractMessage
{

public const uint Id = 5544;
public override uint MessageId
{
    get { return Id; }
}

public string suggestion;
        

public CharacterNameSuggestionSuccessMessage()
{
}

public CharacterNameSuggestionSuccessMessage(string suggestion)
        {
            this.suggestion = suggestion;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteUTF(suggestion);
            

}

public override void Deserialize(IDataReader reader)
{

suggestion = reader.ReadUTF();
            

}


}


}