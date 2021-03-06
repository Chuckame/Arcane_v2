


















// Generated on 05/16/2016 23:27:39
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class InteractiveElement : AbstractType
{

public const short Id = 80;
public override short TypeId { get { return Id; } }

public int elementId;
        public int elementTypeId;
        public Types.InteractiveElementSkill[] enabledSkills;
        public Types.InteractiveElementSkill[] disabledSkills;
        

public InteractiveElement()
{
}

public InteractiveElement(int elementId, int elementTypeId, Types.InteractiveElementSkill[] enabledSkills, Types.InteractiveElementSkill[] disabledSkills)
        {
            this.elementId = elementId;
            this.elementTypeId = elementTypeId;
            this.enabledSkills = enabledSkills;
            this.disabledSkills = disabledSkills;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(elementId);
            writer.WriteInt(elementTypeId);
            writer.WriteUShort((ushort)enabledSkills.Length);
            foreach (var entry in enabledSkills)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
            }
            writer.WriteUShort((ushort)disabledSkills.Length);
            foreach (var entry in disabledSkills)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
            }
            

}

public override void Deserialize(IDataReader reader)
{

elementId = reader.ReadInt();
            if (elementId < 0)
                throw new Exception("Forbidden value on elementId = " + elementId + ", it doesn't respect the following condition : elementId < 0");
            elementTypeId = reader.ReadInt();
            var limit = reader.ReadUShort();
            enabledSkills = new Types.InteractiveElementSkill[limit];
            for (int i = 0; i < limit; i++)
            {
                 enabledSkills[i] = Types.ProtocolTypeManager.GetInstance<Types.InteractiveElementSkill>(reader.ReadShort());
                 enabledSkills[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            disabledSkills = new Types.InteractiveElementSkill[limit];
            for (int i = 0; i < limit; i++)
            {
                 disabledSkills[i] = Types.ProtocolTypeManager.GetInstance<Types.InteractiveElementSkill>(reader.ReadShort());
                 disabledSkills[i].Deserialize(reader);
            }
            

}


}


}