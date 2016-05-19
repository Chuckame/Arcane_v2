


















// Generated on 05/16/2016 23:27:37
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class CharacterMinimalPlusLookAndGradeInformations : CharacterMinimalPlusLookInformations
{

public new const short Id = 193;
public override short TypeId { get { return Id; } }

public int grade;
        

public CharacterMinimalPlusLookAndGradeInformations()
{
}

public CharacterMinimalPlusLookAndGradeInformations(int id, byte level, string name, Types.EntityLook entityLook, int grade)
         : base(id, level, name, entityLook)
        {
            this.grade = grade;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteInt(grade);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            grade = reader.ReadInt();
            if (grade < 0)
                throw new Exception("Forbidden value on grade = " + grade + ", it doesn't respect the following condition : grade < 0");
            

}


}


}