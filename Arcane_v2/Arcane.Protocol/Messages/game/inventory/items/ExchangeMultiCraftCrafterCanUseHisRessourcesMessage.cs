


















// Generated on 05/16/2016 23:27:34
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class ExchangeMultiCraftCrafterCanUseHisRessourcesMessage : AbstractMessage
{

public const uint Id = 6020;
public override uint MessageId
{
    get { return Id; }
}

public bool allowed;
        

public ExchangeMultiCraftCrafterCanUseHisRessourcesMessage()
{
}

public ExchangeMultiCraftCrafterCanUseHisRessourcesMessage(bool allowed)
        {
            this.allowed = allowed;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteBoolean(allowed);
            

}

public override void Deserialize(IDataReader reader)
{

allowed = reader.ReadBoolean();
            

}


}


}