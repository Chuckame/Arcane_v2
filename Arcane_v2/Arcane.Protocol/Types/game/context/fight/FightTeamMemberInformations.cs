


















// Generated on 05/16/2016 23:27:38
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class FightTeamMemberInformations : AbstractType
{

public const short Id = 44;
public override short TypeId { get { return Id; } }

public int id;
        

public FightTeamMemberInformations()
{
}

public FightTeamMemberInformations(int id)
        {
            this.id = id;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(id);
            

}

public override void Deserialize(IDataReader reader)
{

id = reader.ReadInt();
            

}


}


}