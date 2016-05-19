


















// Generated on 05/16/2016 23:27:37
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class DownloadPartMessage : AbstractMessage
{

public const uint Id = 1503;
public override uint MessageId
{
    get { return Id; }
}

public string id;
        

public DownloadPartMessage()
{
}

public DownloadPartMessage(string id)
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