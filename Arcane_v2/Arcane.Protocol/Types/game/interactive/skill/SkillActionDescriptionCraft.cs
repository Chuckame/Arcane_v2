


















// Generated on 05/16/2016 23:27:39
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class SkillActionDescriptionCraft : SkillActionDescription
{

public new const short Id = 100;
public override short TypeId { get { return Id; } }

public sbyte maxSlots;
        public sbyte probability;
        

public SkillActionDescriptionCraft()
{
}

public SkillActionDescriptionCraft(short skillId, sbyte maxSlots, sbyte probability)
         : base(skillId)
        {
            this.maxSlots = maxSlots;
            this.probability = probability;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteSByte(maxSlots);
            writer.WriteSByte(probability);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            maxSlots = reader.ReadSByte();
            if (maxSlots < 0)
                throw new Exception("Forbidden value on maxSlots = " + maxSlots + ", it doesn't respect the following condition : maxSlots < 0");
            probability = reader.ReadSByte();
            if (probability < 0)
                throw new Exception("Forbidden value on probability = " + probability + ", it doesn't respect the following condition : probability < 0");
            

}


}


}