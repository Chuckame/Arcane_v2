


















// Generated on 05/16/2016 23:27:37
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class CharacterBaseInformations : CharacterMinimalPlusLookInformations
{

public new const short Id = 45;
public override short TypeId { get { return Id; } }

public sbyte breed;
        public bool sex;
        

public CharacterBaseInformations()
{
}

public CharacterBaseInformations(int id, byte level, string name, Types.EntityLook entityLook, sbyte breed, bool sex)
         : base(id, level, name, entityLook)
        {
            this.breed = breed;
            this.sex = sex;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteSByte(breed);
            writer.WriteBoolean(sex);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            breed = reader.ReadSByte();
            sex = reader.ReadBoolean();
            

}


}


}