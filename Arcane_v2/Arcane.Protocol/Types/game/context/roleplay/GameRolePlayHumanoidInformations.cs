


















// Generated on 05/16/2016 23:27:38
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class GameRolePlayHumanoidInformations : GameRolePlayNamedActorInformations
{

public new const short Id = 159;
public override short TypeId { get { return Id; } }

public Types.HumanInformations humanoidInfo;
        

public GameRolePlayHumanoidInformations()
{
}

public GameRolePlayHumanoidInformations(int contextualId, Types.EntityLook look, Types.EntityDispositionInformations disposition, string name, Types.HumanInformations humanoidInfo)
         : base(contextualId, look, disposition, name)
        {
            this.humanoidInfo = humanoidInfo;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteShort(humanoidInfo.TypeId);
            humanoidInfo.Serialize(writer);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            humanoidInfo = Types.ProtocolTypeManager.GetInstance<Types.HumanInformations>(reader.ReadShort());
            humanoidInfo.Deserialize(reader);
            

}


}


}