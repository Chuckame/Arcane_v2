


















// Generated on 05/16/2016 23:27:37
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class ActorExtendedAlignmentInformations : ActorAlignmentInformations
{

public new const short Id = 202;
public override short TypeId { get { return Id; } }

public ushort honor;
        public ushort honorGradeFloor;
        public ushort honorNextGradeFloor;
        public bool pvpEnabled;
        

public ActorExtendedAlignmentInformations()
{
}

public ActorExtendedAlignmentInformations(sbyte alignmentSide, sbyte alignmentValue, sbyte alignmentGrade, ushort dishonor, int characterPower, ushort honor, ushort honorGradeFloor, ushort honorNextGradeFloor, bool pvpEnabled)
         : base(alignmentSide, alignmentValue, alignmentGrade, dishonor, characterPower)
        {
            this.honor = honor;
            this.honorGradeFloor = honorGradeFloor;
            this.honorNextGradeFloor = honorNextGradeFloor;
            this.pvpEnabled = pvpEnabled;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteUShort(honor);
            writer.WriteUShort(honorGradeFloor);
            writer.WriteUShort(honorNextGradeFloor);
            writer.WriteBoolean(pvpEnabled);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            honor = reader.ReadUShort();
            if (honor < 0 || honor > 20000)
                throw new Exception("Forbidden value on honor = " + honor + ", it doesn't respect the following condition : honor < 0 || honor > 20000");
            honorGradeFloor = reader.ReadUShort();
            if (honorGradeFloor < 0 || honorGradeFloor > 20000)
                throw new Exception("Forbidden value on honorGradeFloor = " + honorGradeFloor + ", it doesn't respect the following condition : honorGradeFloor < 0 || honorGradeFloor > 20000");
            honorNextGradeFloor = reader.ReadUShort();
            if (honorNextGradeFloor < 0 || honorNextGradeFloor > 20000)
                throw new Exception("Forbidden value on honorNextGradeFloor = " + honorNextGradeFloor + ", it doesn't respect the following condition : honorNextGradeFloor < 0 || honorNextGradeFloor > 20000");
            pvpEnabled = reader.ReadBoolean();
            

}


}


}