


















// Generated on 05/16/2016 23:27:38
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class GameRolePlayMerchantInformations : GameRolePlayNamedActorInformations
{

public new const short Id = 129;
public override short TypeId { get { return Id; } }

public int sellType;
        

public GameRolePlayMerchantInformations()
{
}

public GameRolePlayMerchantInformations(int contextualId, Types.EntityLook look, Types.EntityDispositionInformations disposition, string name, int sellType)
         : base(contextualId, look, disposition, name)
        {
            this.sellType = sellType;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteInt(sellType);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            sellType = reader.ReadInt();
            if (sellType < 0)
                throw new Exception("Forbidden value on sellType = " + sellType + ", it doesn't respect the following condition : sellType < 0");
            

}


}


}