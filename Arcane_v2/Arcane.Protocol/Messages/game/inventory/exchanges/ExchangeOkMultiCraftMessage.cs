


















// Generated on 05/16/2016 23:27:33
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class ExchangeOkMultiCraftMessage : AbstractMessage
{

public const uint Id = 5768;
public override uint MessageId
{
    get { return Id; }
}

public int initiatorId;
        public int otherId;
        public sbyte role;
        

public ExchangeOkMultiCraftMessage()
{
}

public ExchangeOkMultiCraftMessage(int initiatorId, int otherId, sbyte role)
        {
            this.initiatorId = initiatorId;
            this.otherId = otherId;
            this.role = role;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(initiatorId);
            writer.WriteInt(otherId);
            writer.WriteSByte(role);
            

}

public override void Deserialize(IDataReader reader)
{

initiatorId = reader.ReadInt();
            if (initiatorId < 0)
                throw new Exception("Forbidden value on initiatorId = " + initiatorId + ", it doesn't respect the following condition : initiatorId < 0");
            otherId = reader.ReadInt();
            if (otherId < 0)
                throw new Exception("Forbidden value on otherId = " + otherId + ", it doesn't respect the following condition : otherId < 0");
            role = reader.ReadSByte();
            

}


}


}