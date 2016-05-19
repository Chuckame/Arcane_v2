


















// Generated on 05/16/2016 23:27:37
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class GetPartInfoMessage : AbstractMessage
{

public const uint Id = 1506;
public override uint MessageId
{
    get { return Id; }
}

public string id;
        

public GetPartInfoMessage()
{
}

public GetPartInfoMessage(string id)
        {
            this.id = id;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteUTF(id);
            

}

public override void Deserialize(IDataReader reader)
{

id = reader.ReadUTF();
            

}


}


}