


















// Generated on 05/16/2016 23:27:24
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class CharacterCreationResultMessage : AbstractMessage
{

public const uint Id = 161;
public override uint MessageId
{
    get { return Id; }
}

public sbyte result;
        

public CharacterCreationResultMessage()
{
}

public CharacterCreationResultMessage(sbyte result)
        {
            this.result = result;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteSByte(result);
            

}

public override void Deserialize(IDataReader reader)
{

result = reader.ReadSByte();
            if (result < 0)
                throw new Exception("Forbidden value on result = " + result + ", it doesn't respect the following condition : result < 0");
            

}


}


}