


















// Generated on 05/16/2016 23:27:35
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class ObjectUseMultipleMessage : ObjectUseMessage
{

public new const uint Id = 6234;
public override uint MessageId
{
    get { return Id; }
}

public int quantity;
        

public ObjectUseMultipleMessage()
{
}

public ObjectUseMultipleMessage(int objectUID, int quantity)
         : base(objectUID)
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