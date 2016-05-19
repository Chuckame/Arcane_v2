


















// Generated on 05/16/2016 23:27:21
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class IdentificationFailedBannedMessage : IdentificationFailedMessage
{

public new const uint Id = 6174;
public override uint MessageId
{
    get { return Id; }
}

public double banEndDate;
        

public IdentificationFailedBannedMessage()
{
}

public IdentificationFailedBannedMessage(sbyte reason, double banEndDate)
         : base(reason)
        {
            this.banEndDate = banEndDate;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteDouble(banEndDate);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            banEndDate = reader.ReadDouble();
            if (banEndDate < 0)
                throw new Exception("Forbidden value on banEndDate = " + banEndDate + ", it doesn't respect the following condition : banEndDate < 0");
            

}


}


}