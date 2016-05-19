


















// Generated on 05/16/2016 23:27:38
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class GameFightMonsterWithAlignmentInformations : GameFightMonsterInformations
{

public new const short Id = 203;
public override short TypeId { get { return Id; } }

public Types.ActorAlignmentInformations alignmentInfos;
        

public GameFightMonsterWithAlignmentInformations()
{
}

public GameFightMonsterWithAlignmentInformations(int contextualId, Types.EntityLook look, Types.EntityDispositionInformations disposition, sbyte teamId, bool alive, Types.GameFightMinimalStats stats, short creatureGenericId, sbyte creatureGrade, Types.ActorAlignmentInformations alignmentInfos)
         : base(contextualId, look, disposition, teamId, alive, stats, creatureGenericId, creatureGrade)
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