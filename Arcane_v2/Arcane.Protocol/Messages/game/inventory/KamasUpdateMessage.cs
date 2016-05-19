


















// Generated on 05/16/2016 23:27:32
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class KamasUpdateMessage : AbstractMessage
{

public const uint Id = 5537;
public override uint MessageId
{
    get { return Id; }
}

public int kamasTotal;
        

public KamasUpdateMessage()
{
}

public KamasUpdateMessage(int kamasTotal)
        {
            this.kamasTotal = kamasTotal;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(kamasTotal);
            

}

public override void Deserialize(IDataReader reader)
{

kamasTotal = reader.ReadInt();
            

}


}


}