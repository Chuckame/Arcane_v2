


















// Generated on 05/16/2016 23:27:32
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class TaxCollectorAttackedResultMessage : AbstractMessage
{

public const uint Id = 5635;
public override uint MessageId
{
    get { return Id; }
}

public bool deadOrAlive;
        public Types.TaxCollectorBasicInformations basicInfos;
        

public TaxCollectorAttackedResultMessage()
{
}

public TaxCollectorAttackedResultMessage(bool deadOrAlive, Types.TaxCollectorBasicInformations basicInfos)
        {
            this.deadOrAlive = deadOrAlive;
            this.basicInfos = basicInfos;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteBoolean(deadOrAlive);
            basicInfos.Serialize(writer);
            

}

public override void Deserialize(IDataReader reader)
{

deadOrAlive = reader.ReadBoolean();
            basicInfos = new Types.TaxCollectorBasicInformations();
            basicInfos.Deserialize(reader);
            

}


}


}