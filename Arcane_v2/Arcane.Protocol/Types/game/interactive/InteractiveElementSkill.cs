


















// Generated on 05/16/2016 23:27:39
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class InteractiveElementSkill : AbstractType
{

public const short Id = 219;
public override short TypeId { get { return Id; } }

public int skillId;
        public int skillInstanceUid;
        

public InteractiveElementSkill()
{
}

public InteractiveElementSkill(int skillId, int skillInstanceUid)
        {
            this.skillId = skillId;
            this.skillInstanceUid = skillInstanceUid;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(skillId);
            writer.WriteInt(skillInstanceUid);
            

}

public override void Deserialize(IDataReader reader)
{

skillId = reader.ReadInt();
            if (skillId < 0)
                throw new Exception("Forbidden value on skillId = " + skillId + ", it doesn't respect the following condition : skillId < 0");
            skillInstanceUid = reader.ReadInt();
            if (skillInstanceUid < 0)
                throw new Exception("Forbidden value on skillInstanceUid = " + skillInstanceUid + ", it doesn't respect the following condition : skillInstanceUid < 0");
            

}


}


}