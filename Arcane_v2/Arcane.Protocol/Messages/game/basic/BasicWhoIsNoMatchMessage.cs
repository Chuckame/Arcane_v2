


















// Generated on 05/16/2016 23:27:24
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class BasicWhoIsNoMatchMessage : AbstractMessage
{

public const uint Id = 179;
public override uint MessageId
{
    get { return Id; }
}

public string search;
        

public BasicWhoIsNoMatchMessage()
{
}

public BasicWhoIsNoMatchMessage(string search)
        {
            this.search = search;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteUTF(search);
            

}

public override void Deserialize(IDataReader reader)
{

search = reader.ReadUTF();
            

}


}


}