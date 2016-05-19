


















// Generated on 05/16/2016 23:27:39
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class InteractiveElementNamedSkill : InteractiveElementSkill
{

public new const short Id = 220;
public override short TypeId { get { return Id; } }

public int nameId;
        

public InteractiveElementNamedSkill()
{
}

public InteractiveElementNamedSkill(int skillId, int skillInstanceUid, int nameId)
         : base(skillId, skillInstanceUid)
        {
            this.nameId = nameId;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteInt(nameId);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            nameId = reader.ReadInt();
            if (nameId < 0)
                throw new Exception("Forbidden value on nameId = " + nameId + ", it doesn't respect the following condition : nameId < 0");
            

}


}


}