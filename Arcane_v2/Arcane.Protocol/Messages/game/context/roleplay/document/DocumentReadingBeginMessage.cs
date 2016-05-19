


















// Generated on 05/16/2016 23:27:27
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class DocumentReadingBeginMessage : AbstractMessage
{

public const uint Id = 5675;
public override uint MessageId
{
    get { return Id; }
}

public short documentId;
        

public DocumentReadingBeginMessage()
{
}

public DocumentReadingBeginMessage(short documentId)
        {
            this.documentId = documentId;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteShort(documentId);
            

}

public override void Deserialize(IDataReader reader)
{

documentId = reader.ReadShort();
            if (documentId < 0)
                throw new Exception("Forbidden value on documentId = " + documentId + ", it doesn't respect the following condition : documentId < 0");
            

}


}


}