


















// Generated on 05/16/2016 23:27:37
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class CharacterBaseCharacteristic : AbstractType
{

public const short Id = 4;
public override short TypeId { get { return Id; } }

public short @base;
        public short objectsAndMountBonus;
        public short alignGiftBonus;
        public short contextModif;
        

public CharacterBaseCharacteristic()
{
}

public CharacterBaseCharacteristic(short @base, short objectsAndMountBonus, short alignGiftBonus, short contextModif)
        {
            this.@base = @base;
            this.objectsAndMountBonus = objectsAndMountBonus;
            this.alignGiftBonus = alignGiftBonus;
            this.contextModif = contextModif;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteShort(@base);
            writer.WriteShort(objectsAndMountBonus);
            writer.WriteShort(alignGiftBonus);
            writer.WriteShort(contextModif);
            

}

public override void Deserialize(IDataReader reader)
{

@base = reader.ReadShort();
            objectsAndMountBonus = reader.ReadShort();
            alignGiftBonus = reader.ReadShort();
            contextModif = reader.ReadShort();
            

}


}


}