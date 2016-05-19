


















// Generated on 05/16/2016 23:27:30
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class ValidateSpellForgetMessage : AbstractMessage
{

public const uint Id = 1700;
public override uint MessageId
{
    get { return Id; }
}

public short spellId;
        

public ValidateSpellForgetMessage()
{
}

public ValidateSpellForgetMessage(short spellId)
        {
            this.spellId = spellId;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteShort(spellId);
            

}

public override void Deserialize(IDataReader reader)
{

spellId = reader.ReadShort();
            if (spellId < 0)
                throw new Exception("Forbidden value on spellId = " + spellId + ", it doesn't respect the following condition : spellId < 0");
            

}


}


}