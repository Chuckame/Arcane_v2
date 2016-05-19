


















// Generated on 05/16/2016 23:27:39
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class ObjectEffectCreature : ObjectEffect
{

public new const short Id = 71;
public override short TypeId { get { return Id; } }

public short monsterFamilyId;
        

public ObjectEffectCreature()
{
}

public ObjectEffectCreature(short actionId, short monsterFamilyId)
         : base(actionId)
        {
            this.monsterFamilyId = monsterFamilyId;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteShort(monsterFamilyId);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            monsterFamilyId = reader.ReadShort();
            if (monsterFamilyId < 0)
                throw new Exception("Forbidden value on monsterFamilyId = " + monsterFamilyId + ", it doesn't respect the following condition : monsterFamilyId < 0");
            

}


}


}