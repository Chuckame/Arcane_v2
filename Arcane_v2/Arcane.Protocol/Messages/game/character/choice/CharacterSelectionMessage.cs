


















// Generated on 05/16/2016 23:27:24
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class CharacterSelectionMessage : AbstractMessage
{

public const uint Id = 152;
public override uint MessageId
{
    get { return Id; }
}

public int id;
        

public CharacterSelectionMessage()
{
}

public CharacterSelectionMessage(int id)
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
            if (id < 1 || id > 2147483647)
                throw new Exception("Forbidden value on id = " + id + ", it doesn't respect the following condition : id < 1 || id > 2147483647");
            

}


}


}