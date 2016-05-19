


















// Generated on 05/16/2016 23:27:38
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class PartyMemberArenaInformations : PartyMemberInformations
{

public new const short Id = 391;
public override short TypeId { get { return Id; } }

public short rank;
        

public PartyMemberArenaInformations()
{
}

public PartyMemberArenaInformations(int id, byte level, string name, Types.EntityLook entityLook, int lifePoints, int maxLifePoints, short prospecting, byte regenRate, short initiative, bool pvpEnabled, sbyte alignmentSide, short rank)
         : base(id, level, name, entityLook, lifePoints, maxLifePoints, prospecting, regenRate, initiative, pvpEnabled, alignmentSide)
        {
            this.rank = rank;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteShort(rank);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            rank = reader.ReadShort();
            if (rank < 0 || rank > 2300)
                throw new Exception("Forbidden value on rank = " + rank + ", it doesn't respect the following condition : rank < 0 || rank > 2300");
            

}


}


}