


















// Generated on 05/16/2016 23:27:38
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class PartyMemberInformations : CharacterMinimalPlusLookInformations
{

public new const short Id = 90;
public override short TypeId { get { return Id; } }

public int lifePoints;
        public int maxLifePoints;
        public short prospecting;
        public byte regenRate;
        public short initiative;
        public bool pvpEnabled;
        public sbyte alignmentSide;
        

public PartyMemberInformations()
{
}

public PartyMemberInformations(int id, byte level, string name, Types.EntityLook entityLook, int lifePoints, int maxLifePoints, short prospecting, byte regenRate, short initiative, bool pvpEnabled, sbyte alignmentSide)
         : base(id, level, name, entityLook)
        {
            this.lifePoints = lifePoints;
            this.maxLifePoints = maxLifePoints;
            this.prospecting = prospecting;
            this.regenRate = regenRate;
            this.initiative = initiative;
            this.pvpEnabled = pvpEnabled;
            this.alignmentSide = alignmentSide;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteInt(lifePoints);
            writer.WriteInt(maxLifePoints);
            writer.WriteShort(prospecting);
            writer.WriteByte(regenRate);
            writer.WriteShort(initiative);
            writer.WriteBoolean(pvpEnabled);
            writer.WriteSByte(alignmentSide);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            lifePoints = reader.ReadInt();
            if (lifePoints < 0)
                throw new Exception("Forbidden value on lifePoints = " + lifePoints + ", it doesn't respect the following condition : lifePoints < 0");
            maxLifePoints = reader.ReadInt();
            if (maxLifePoints < 0)
                throw new Exception("Forbidden value on maxLifePoints = " + maxLifePoints + ", it doesn't respect the following condition : maxLifePoints < 0");
            prospecting = reader.ReadShort();
            if (prospecting < 0)
                throw new Exception("Forbidden value on prospecting = " + prospecting + ", it doesn't respect the following condition : prospecting < 0");
            regenRate = reader.ReadByte();
            if (regenRate < 0 || regenRate > 255)
                throw new Exception("Forbidden value on regenRate = " + regenRate + ", it doesn't respect the following condition : regenRate < 0 || regenRate > 255");
            initiative = reader.ReadShort();
            if (initiative < 0)
                throw new Exception("Forbidden value on initiative = " + initiative + ", it doesn't respect the following condition : initiative < 0");
            pvpEnabled = reader.ReadBoolean();
            alignmentSide = reader.ReadSByte();
            

}


}


}