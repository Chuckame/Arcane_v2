


















// Generated on 05/16/2016 23:27:32
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class TaxCollectorFireRequestMessage : AbstractMessage
{

public const uint Id = 5682;
public override uint MessageId
{
    get { return Id; }
}

public int collectorId;
        

public TaxCollectorFireRequestMessage()
{
}

public TaxCollectorFireRequestMessage(int collectorId)
        {
            this.collectorId = collectorId;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(collectorId);
            

}

public override void Deserialize(IDataReader reader)
{

collectorId = reader.ReadInt();
            

}


}


}