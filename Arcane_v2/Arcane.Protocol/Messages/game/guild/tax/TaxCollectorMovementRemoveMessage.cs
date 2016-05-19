


















// Generated on 05/16/2016 23:27:32
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class TaxCollectorMovementRemoveMessage : AbstractMessage
{

public const uint Id = 5915;
public override uint MessageId
{
    get { return Id; }
}

public int collectorId;
        

public TaxCollectorMovementRemoveMessage()
{
}

public TaxCollectorMovementRemoveMessage(int collectorId)
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