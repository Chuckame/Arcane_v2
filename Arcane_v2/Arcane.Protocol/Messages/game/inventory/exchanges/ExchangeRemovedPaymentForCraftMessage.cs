


















// Generated on 05/16/2016 23:27:33
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class ExchangeRemovedPaymentForCraftMessage : AbstractMessage
{

public const uint Id = 6031;
public override uint MessageId
{
    get { return Id; }
}

public bool onlySuccess;
        public int objectUID;
        

public ExchangeRemovedPaymentForCraftMessage()
{
}

public ExchangeRemovedPaymentForCraftMessage(bool onlySuccess, int objectUID)
        {
            this.onlySuccess = onlySuccess;
            this.objectUID = objectUID;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteBoolean(onlySuccess);
            writer.WriteInt(objectUID);
            

}

public override void Deserialize(IDataReader reader)
{

onlySuccess = reader.ReadBoolean();
            objectUID = reader.ReadInt();
            if (objectUID < 0)
                throw new Exception("Forbidden value on objectUID = " + objectUID + ", it doesn't respect the following condition : objectUID < 0");
            

}


}


}