


















// Generated on 05/16/2016 23:27:37
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class FightEntityDispositionInformations : EntityDispositionInformations
{

public new const short Id = 217;
public override short TypeId { get { return Id; } }

public int carryingCharacterId;
        

public FightEntityDispositionInformations()
{
}

public FightEntityDispositionInformations(short cellId, sbyte direction, int carryingCharacterId)
         : base(cellId, direction)
        {
            this.carryingCharacterId = carryingCharacterId;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteInt(carryingCharacterId);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            carryingCharacterId = reader.ReadInt();
            

}


}


}