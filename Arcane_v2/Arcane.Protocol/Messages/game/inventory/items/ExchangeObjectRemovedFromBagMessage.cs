


















// Generated on 05/16/2016 23:27:34
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class ExchangeObjectRemovedFromBagMessage : ExchangeObjectMessage
{

public new const uint Id = 6010;
public override uint MessageId
{
    get { return Id; }
}

public int objectUID;
        

public ExchangeObjectRemovedFromBagMessage()
{
}

public ExchangeObjectRemovedFromBagMessage(bool remote, int objectUID)
         : base(remote)
        {
            this.objectUID = objectUID;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteInt(objectUID);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            objectUID = reader.ReadInt();
            if (objectUID < 0)
                throw new Exception("Forbidden value on objectUID = " + objectUID + ", it doesn't respect the following condition : objectUID < 0");
            

}


}


}