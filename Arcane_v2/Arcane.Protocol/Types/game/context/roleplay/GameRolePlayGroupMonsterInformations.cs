


















// Generated on 05/16/2016 23:27:38
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class GameRolePlayGroupMonsterInformations : GameRolePlayActorInformations
{

public new const short Id = 160;
public override short TypeId { get { return Id; } }

public int mainCreatureGenericId;
        public sbyte mainCreatureGrade;
        public Types.MonsterInGroupInformations[] underlings;
        public short ageBonus;
        public sbyte alignmentSide;
        public bool keyRingBonus;
        

public GameRolePlayGroupMonsterInformations()
{
}

public GameRolePlayGroupMonsterInformations(int contextualId, Types.EntityLook look, Types.EntityDispositionInformations disposition, int mainCreatureGenericId, sbyte mainCreatureGrade, Types.MonsterInGroupInformations[] underlings, short ageBonus, sbyte alignmentSide, bool keyRingBonus)
         : base(contextualId, look, disposition)
        {
            this.mainCreatureGenericId = mainCreatureGenericId;
            this.mainCreatureGrade = mainCreatureGrade;
            this.underlings = underlings;
            this.ageBonus = ageBonus;
            this.alignmentSide = alignmentSide;
            this.keyRingBonus = keyRingBonus;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteInt(mainCreatureGenericId);
            writer.WriteSByte(mainCreatureGrade);
            writer.WriteUShort((ushort)underlings.Length);
            foreach (var entry in underlings)
            {
                 entry.Serialize(writer);
            }
            writer.WriteShort(ageBonus);
            writer.WriteSByte(alignmentSide);
            writer.WriteBoolean(keyRingBonus);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            mainCreatureGenericId = reader.ReadInt();
            mainCreatureGrade = reader.ReadSByte();
            if (mainCreatureGrade < 0)
                throw new Exception("Forbidden value on mainCreatureGrade = " + mainCreatureGrade + ", it doesn't respect the following condition : mainCreatureGrade < 0");
            var limit = reader.ReadUShort();
            underlings = new Types.MonsterInGroupInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 underlings[i] = new Types.MonsterInGroupInformations();
                 underlings[i].Deserialize(reader);
            }
            ageBonus = reader.ReadShort();
            if (ageBonus < -1 || ageBonus > 1000)
                throw new Exception("Forbidden value on ageBonus = " + ageBonus + ", it doesn't respect the following condition : ageBonus < -1 || ageBonus > 1000");
            alignmentSide = reader.ReadSByte();
            keyRingBonus = reader.ReadBoolean();
            

}


}


}