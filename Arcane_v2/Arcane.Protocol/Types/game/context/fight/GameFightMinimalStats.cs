


















// Generated on 05/16/2016 23:27:38
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class GameFightMinimalStats : AbstractType
{

public const short Id = 31;
public override short TypeId { get { return Id; } }

public int lifePoints;
        public int maxLifePoints;
        public int baseMaxLifePoints;
        public int permanentDamagePercent;
        public int shieldPoints;
        public short actionPoints;
        public short maxActionPoints;
        public short movementPoints;
        public short maxMovementPoints;
        public int summoner;
        public bool summoned;
        public short neutralElementResistPercent;
        public short earthElementResistPercent;
        public short waterElementResistPercent;
        public short airElementResistPercent;
        public short fireElementResistPercent;
        public short neutralElementFixedResist;
        public short earthElementFixedResist;
        public short waterElementFixedResist;
        public short airElementFixedResist;
        public short fireElementFixedResist;
        public short criticalDamageFixedResist;
        public short pushDamageFixedResist;
        public short dodgePALostProbability;
        public short dodgePMLostProbability;
        public short tackleBlock;
        public short tackleEvade;
        public sbyte invisibilityState;
        

public GameFightMinimalStats()
{
}

public GameFightMinimalStats(int lifePoints, int maxLifePoints, int baseMaxLifePoints, int permanentDamagePercent, int shieldPoints, short actionPoints, short maxActionPoints, short movementPoints, short maxMovementPoints, int summoner, bool summoned, short neutralElementResistPercent, short earthElementResistPercent, short waterElementResistPercent, short airElementResistPercent, short fireElementResistPercent, short neutralElementFixedResist, short earthElementFixedResist, short waterElementFixedResist, short airElementFixedResist, short fireElementFixedResist, short criticalDamageFixedResist, short pushDamageFixedResist, short dodgePALostProbability, short dodgePMLostProbability, short tackleBlock, short tackleEvade, sbyte invisibilityState)
        {
            this.lifePoints = lifePoints;
            this.maxLifePoints = maxLifePoints;
            this.baseMaxLifePoints = baseMaxLifePoints;
            this.permanentDamagePercent = permanentDamagePercent;
            this.shieldPoints = shieldPoints;
            this.actionPoints = actionPoints;
            this.maxActionPoints = maxActionPoints;
            this.movementPoints = movementPoints;
            this.maxMovementPoints = maxMovementPoints;
            this.summoner = summoner;
            this.summoned = summoned;
            this.neutralElementResistPercent = neutralElementResistPercent;
            this.earthElementResistPercent = earthElementResistPercent;
            this.waterElementResistPercent = waterElementResistPercent;
            this.airElementResistPercent = airElementResistPercent;
            this.fireElementResistPercent = fireElementResistPercent;
            this.neutralElementFixedResist = neutralElementFixedResist;
            this.earthElementFixedResist = earthElementFixedResist;
            this.waterElementFixedResist = waterElementFixedResist;
            this.airElementFixedResist = airElementFixedResist;
            this.fireElementFixedResist = fireElementFixedResist;
            this.criticalDamageFixedResist = criticalDamageFixedResist;
            this.pushDamageFixedResist = pushDamageFixedResist;
            this.dodgePALostProbability = dodgePALostProbability;
            this.dodgePMLostProbability = dodgePMLostProbability;
            this.tackleBlock = tackleBlock;
            this.tackleEvade = tackleEvade;
            this.invisibilityState = invisibilityState;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(lifePoints);
            writer.WriteInt(maxLifePoints);
            writer.WriteInt(baseMaxLifePoints);
            writer.WriteInt(permanentDamagePercent);
            writer.WriteInt(shieldPoints);
            writer.WriteShort(actionPoints);
            writer.WriteShort(maxActionPoints);
            writer.WriteShort(movementPoints);
            writer.WriteShort(maxMovementPoints);
            writer.WriteInt(summoner);
            writer.WriteBoolean(summoned);
            writer.WriteShort(neutralElementResistPercent);
            writer.WriteShort(earthElementResistPercent);
            writer.WriteShort(waterElementResistPercent);
            writer.WriteShort(airElementResistPercent);
            writer.WriteShort(fireElementResistPercent);
            writer.WriteShort(neutralElementFixedResist);
            writer.WriteShort(earthElementFixedResist);
            writer.WriteShort(waterElementFixedResist);
            writer.WriteShort(airElementFixedResist);
            writer.WriteShort(fireElementFixedResist);
            writer.WriteShort(criticalDamageFixedResist);
            writer.WriteShort(pushDamageFixedResist);
            writer.WriteShort(dodgePALostProbability);
            writer.WriteShort(dodgePMLostProbability);
            writer.WriteShort(tackleBlock);
            writer.WriteShort(tackleEvade);
            writer.WriteSByte(invisibilityState);
            

}

public override void Deserialize(IDataReader reader)
{

lifePoints = reader.ReadInt();
            if (lifePoints < 0)
                throw new Exception("Forbidden value on lifePoints = " + lifePoints + ", it doesn't respect the following condition : lifePoints < 0");
            maxLifePoints = reader.ReadInt();
            if (maxLifePoints < 0)
                throw new Exception("Forbidden value on maxLifePoints = " + maxLifePoints + ", it doesn't respect the following condition : maxLifePoints < 0");
            baseMaxLifePoints = reader.ReadInt();
            if (baseMaxLifePoints < 0)
                throw new Exception("Forbidden value on baseMaxLifePoints = " + baseMaxLifePoints + ", it doesn't respect the following condition : baseMaxLifePoints < 0");
            permanentDamagePercent = reader.ReadInt();
            if (permanentDamagePercent < 0)
                throw new Exception("Forbidden value on permanentDamagePercent = " + permanentDamagePercent + ", it doesn't respect the following condition : permanentDamagePercent < 0");
            shieldPoints = reader.ReadInt();
            if (shieldPoints < 0)
                throw new Exception("Forbidden value on shieldPoints = " + shieldPoints + ", it doesn't respect the following condition : shieldPoints < 0");
            actionPoints = reader.ReadShort();
            maxActionPoints = reader.ReadShort();
            movementPoints = reader.ReadShort();
            maxMovementPoints = reader.ReadShort();
            summoner = reader.ReadInt();
            summoned = reader.ReadBoolean();
            neutralElementResistPercent = reader.ReadShort();
            earthElementResistPercent = reader.ReadShort();
            waterElementResistPercent = reader.ReadShort();
            airElementResistPercent = reader.ReadShort();
            fireElementResistPercent = reader.ReadShort();
            neutralElementFixedResist = reader.ReadShort();
            earthElementFixedResist = reader.ReadShort();
            waterElementFixedResist = reader.ReadShort();
            airElementFixedResist = reader.ReadShort();
            fireElementFixedResist = reader.ReadShort();
            criticalDamageFixedResist = reader.ReadShort();
            pushDamageFixedResist = reader.ReadShort();
            dodgePALostProbability = reader.ReadShort();
            if (dodgePALostProbability < 0)
                throw new Exception("Forbidden value on dodgePALostProbability = " + dodgePALostProbability + ", it doesn't respect the following condition : dodgePALostProbability < 0");
            dodgePMLostProbability = reader.ReadShort();
            if (dodgePMLostProbability < 0)
                throw new Exception("Forbidden value on dodgePMLostProbability = " + dodgePMLostProbability + ", it doesn't respect the following condition : dodgePMLostProbability < 0");
            tackleBlock = reader.ReadShort();
            if (tackleBlock < 0)
                throw new Exception("Forbidden value on tackleBlock = " + tackleBlock + ", it doesn't respect the following condition : tackleBlock < 0");
            tackleEvade = reader.ReadShort();
            if (tackleEvade < 0)
                throw new Exception("Forbidden value on tackleEvade = " + tackleEvade + ", it doesn't respect the following condition : tackleEvade < 0");
            invisibilityState = reader.ReadSByte();
            

}


}


}