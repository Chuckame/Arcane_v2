


















// Generated on 05/16/2016 23:27:39
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class SkillActionDescription : AbstractType
{

public const short Id = 102;
public override short TypeId { get { return Id; } }

public short skillId;
        

public SkillActionDescription()
{
}

public SkillActionDescription(short skillId)
        {
            this.skillId = skillId;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteShort(skillId);
            

}

public override void Deserialize(IDataReader reader)
{

skillId = reader.ReadShort();
            if (skillId < 0)
                throw new Exception("Forbidden value on skillId = " + skillId + ", it doesn't respect the following condition : skillId < 0");
            

}


}


}