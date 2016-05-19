


















// Generated on 05/16/2016 23:27:23
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class GameActionFightNoSpellCastMessage : AbstractMessage
{

public const uint Id = 6132;
public override uint MessageId
{
    get { return Id; }
}

public int spellLevelId;
        

public GameActionFightNoSpellCastMessage()
{
}

public GameActionFightNoSpellCastMessage(int spellLevelId)
        {
            this.spellLevelId = spellLevelId;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(spellLevelId);
            

}

public override void Deserialize(IDataReader reader)
{

spellLevelId = reader.ReadInt();
            if (spellLevelId < 0)
                throw new Exception("Forbidden value on spellLevelId = " + spellLevelId + ", it doesn't respect the following condition : spellLevelId < 0");
            

}


}


}