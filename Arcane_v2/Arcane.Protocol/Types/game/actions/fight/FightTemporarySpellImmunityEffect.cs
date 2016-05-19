


















// Generated on 05/16/2016 23:27:37
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class FightTemporarySpellImmunityEffect : AbstractFightDispellableEffect
{

public new const short Id = 366;
public override short TypeId { get { return Id; } }

public int immuneSpellId;
        

public FightTemporarySpellImmunityEffect()
{
}

public FightTemporarySpellImmunityEffect(int uid, int targetId, short turnDuration, sbyte dispelable, short spellId, int parentBoostUid, int immuneSpellId)
         : base(uid, targetId, turnDuration, dispelable, spellId, parentBoostUid)
        {
            this.immuneSpellId = immuneSpellId;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteInt(immuneSpellId);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            immuneSpellId = reader.ReadInt();
            

}


}


}