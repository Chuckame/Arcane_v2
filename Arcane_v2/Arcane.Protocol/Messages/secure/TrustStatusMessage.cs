


















// Generated on 05/16/2016 23:27:36
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class TrustStatusMessage : AbstractMessage
{

public const uint Id = 6267;
public override uint MessageId
{
    get { return Id; }
}

public bool trusted;
        

public TrustStatusMessage()
{
}

public TrustStatusMessage(bool trusted)
        {
            this.trusted = trusted;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteBoolean(trusted);
            

}

public override void Deserialize(IDataReader reader)
{

trusted = reader.ReadBoolean();
            

}


}


}