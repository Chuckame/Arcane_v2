


















// Generated on 05/16/2016 23:27:38
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class FightTeamMemberMonsterInformations : FightTeamMemberInformations
{

public new const short Id = 6;
public override short TypeId { get { return Id; } }

public int monsterId;
        public sbyte grade;
        

public FightTeamMemberMonsterInformations()
{
}

public FightTeamMemberMonsterInformations(int id, int monsterId, sbyte grade)
         : base(id)
        {
            this.monsterId = monsterId;
            this.grade = grade;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteInt(monsterId);
            writer.WriteSByte(grade);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            monsterId = reader.ReadInt();
            grade = reader.ReadSByte();
            if (grade < 0)
                throw new Exception("Forbidden value on grade = " + grade + ", it doesn't respect the following condition : grade < 0");
            

}


}


}