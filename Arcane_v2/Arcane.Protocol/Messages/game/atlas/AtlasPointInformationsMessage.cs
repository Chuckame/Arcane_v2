


















// Generated on 05/16/2016 23:27:23
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class AtlasPointInformationsMessage : AbstractMessage
{

public const uint Id = 5956;
public override uint MessageId
{
    get { return Id; }
}

public Types.AtlasPointsInformations type;
        

public AtlasPointInformationsMessage()
{
}

public AtlasPointInformationsMessage(Types.AtlasPointsInformations type)
        {
            this.type = type;
        }
        

public override void Serialize(IDataWriter writer)
{

type.Serialize(writer);
            

}

public override void Deserialize(IDataReader reader)
{

type = new Types.AtlasPointsInformations();
            type.Deserialize(reader);
            

}


}


}