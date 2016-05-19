


















// Generated on 05/16/2016 23:27:33
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class ExchangeOnHumanVendorRequestMessage : AbstractMessage
{

public const uint Id = 5772;
public override uint MessageId
{
    get { return Id; }
}

public int humanVendorId;
        public int humanVendorCell;
        

public ExchangeOnHumanVendorRequestMessage()
{
}

public ExchangeOnHumanVendorRequestMessage(int humanVendorId, int humanVendorCell)
        {
            this.humanVendorId = humanVendorId;
            this.humanVendorCell = humanVendorCell;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(humanVendorId);
            writer.WriteInt(humanVendorCell);
            

}

public override void Deserialize(IDataReader reader)
{

humanVendorId = reader.ReadInt();
            if (humanVendorId < 0)
                throw new Exception("Forbidden value on humanVendorId = " + humanVendorId + ", it doesn't respect the following condition : humanVendorId < 0");
            humanVendorCell = reader.ReadInt();
            if (humanVendorCell < 0)
                throw new Exception("Forbidden value on humanVendorCell = " + humanVendorCell + ", it doesn't respect the following condition : humanVendorCell < 0");
            

}


}


}