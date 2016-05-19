


















// Generated on 05/16/2016 23:27:36
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class URLOpenMessage : AbstractMessage
{

public const uint Id = 6266;
public override uint MessageId
{
    get { return Id; }
}

public int urlId;
        

public URLOpenMessage()
{
}

public URLOpenMessage(int urlId)
        {
            this.urlId = urlId;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(urlId);
            

}

public override void Deserialize(IDataReader reader)
{

urlId = reader.ReadInt();
            if (urlId < 0)
                throw new Exception("Forbidden value on urlId = " + urlId + ", it doesn't respect the following condition : urlId < 0");
            

}


}


}