


















// Generated on 05/16/2016 23:27:39
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class SkillActionDescriptionCraftExtended : SkillActionDescriptionCraft
{

public new const short Id = 104;
public override short TypeId { get { return Id; } }

public sbyte thresholdSlots;
        public sbyte optimumProbability;
        

public SkillActionDescriptionCraftExtended()
{
}

public SkillActionDescriptionCraftExtended(short skillId, sbyte maxSlots, sbyte probability, sbyte thresholdSlots, sbyte optimumProbability)
         : base(skillId, maxSlots, probability)
        {
            this.thresholdSlots = thresholdSlots;
            this.optimumProbability = optimumProbability;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteSByte(thresholdSlots);
            writer.WriteSByte(optimumProbability);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            thresholdSlots = reader.ReadSByte();
            if (thresholdSlots < 0)
                throw new Exception("Forbidden value on thresholdSlots = " + thresholdSlots + ", it doesn't respect the following condition : thresholdSlots < 0");
            optimumProbability = reader.ReadSByte();
            if (optimumProbability < 0)
                throw new Exception("Forbidden value on optimumProbability = " + optimumProbability + ", it doesn't respect the following condition : optimumProbability < 0");
            

}


}


}