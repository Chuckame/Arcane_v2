


















// Generated on 05/16/2016 23:27:38
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class GameRolePlayCharacterInformations : GameRolePlayHumanoidInformations
{

public new const short Id = 36;
public override short TypeId { get { return Id; } }

public Types.ActorAlignmentInformations alignmentInfos;
        

public GameRolePlayCharacterInformations()
{
}

public GameRolePlayCharacterInformations(int contextualId, Types.EntityLook look, Types.EntityDispositionInformations disposition, string name, Types.HumanInformations humanoidInfo, Types.ActorAlignmentInformations alignmentInfos)
         : base(contextualId, look, disposition, name, humanoidInfo)
        {
            this.alignmentInfos = alignmentInfos;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            alignmentInfos.Serialize(writer);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            alignmentInfos = new Types.ActorAlignmentInformations();
            alignmentInfos.Deserialize(reader);
            

}


}


}