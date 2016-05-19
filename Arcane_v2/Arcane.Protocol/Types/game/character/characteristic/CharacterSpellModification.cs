


















// Generated on 05/16/2016 23:27:37
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class CharacterSpellModification : AbstractType
{

public const short Id = 215;
public override short TypeId { get { return Id; } }

public sbyte modificationType;
        public short spellId;
        public Types.CharacterBaseCharacteristic value;
        

public CharacterSpellModification()
{
}

public CharacterSpellModification(sbyte modificationType, short spellId, Types.CharacterBaseCharacteristic value)
        {
            this.modificationType = modificationType;
            this.spellId = spellId;
            this.value = value;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteSByte(modificationType);
            writer.WriteShort(spellId);
            value.Serialize(writer);
            

}

public override void Deserialize(IDataReader reader)
{

modificationType = reader.ReadSByte();
            if (modificationType < 0)
                throw new Exception("Forbidden value on modificationType = " + modificationType + ", it doesn't respect the following condition : modificationType < 0");
            spellId = reader.ReadShort();
            if (spellId < 0)
                throw new Exception("Forbidden value on spellId = " + spellId + ", it doesn't respect the following condition : spellId < 0");
            value = new Types.CharacterBaseCharacteristic();
            value.Deserialize(reader);
            

}


}


}