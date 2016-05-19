


















// Generated on 05/16/2016 23:27:21
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class BasicPongMessage : AbstractMessage
{

public const uint Id = 183;
public override uint MessageId
{
    get { return Id; }
}

public bool quiet;
        

public BasicPongMessage()
{
}

public BasicPongMessage(bool quiet)
        {
            this.quiet = quiet;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteBoolean(quiet);
            

}

public override void Deserialize(IDataReader reader)
{

quiet = reader.ReadBoolean();
            

}


}


}