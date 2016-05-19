


















// Generated on 05/16/2016 23:27:32
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class TaxCollectorMovementMessage : AbstractMessage
{

public const uint Id = 5633;
public override uint MessageId
{
    get { return Id; }
}

public bool hireOrFire;
        public Types.TaxCollectorBasicInformations basicInfos;
        public string playerName;
        

public TaxCollectorMovementMessage()
{
}

public TaxCollectorMovementMessage(bool hireOrFire, Types.TaxCollectorBasicInformations basicInfos, string playerName)
        {
            this.hireOrFire = hireOrFire;
            this.basicInfos = basicInfos;
            this.playerName = playerName;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteBoolean(hireOrFire);
            basicInfos.Serialize(writer);
            writer.WriteUTF(playerName);
            

}

public override void Deserialize(IDataReader reader)
{

hireOrFire = reader.ReadBoolean();
            basicInfos = new Types.TaxCollectorBasicInformations();
            basicInfos.Deserialize(reader);
            playerName = reader.ReadUTF();
            

}


}


}