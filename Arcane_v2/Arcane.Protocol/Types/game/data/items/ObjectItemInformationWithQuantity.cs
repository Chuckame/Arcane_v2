


















// Generated on 05/16/2016 23:27:38
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class ObjectItemInformationWithQuantity : ObjectItemMinimalInformation
{

public new const short Id = 387;
public override short TypeId { get { return Id; } }

public int quantity;
        

public ObjectItemInformationWithQuantity()
{
}

public ObjectItemInformationWithQuantity(short objectGID, short powerRate, bool overMax, Types.ObjectEffect[] effects, int quantity)
         : base(objectGID, powerRate, overMax, effects)
        {
            this.quantity = quantity;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteInt(quantity);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            quantity = reader.ReadInt();
            if (quantity < 0)
                throw new Exception("Forbidden value on quantity = " + quantity + ", it doesn't respect the following condition : quantity < 0");
            

}


}


}