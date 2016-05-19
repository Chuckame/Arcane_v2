


















// Generated on 05/16/2016 23:27:36
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class PrismWorldInformationRequestMessage : AbstractMessage
{

public const uint Id = 5985;
public override uint MessageId
{
    get { return Id; }
}

public bool join;
        

public PrismWorldInformationRequestMessage()
{
}

public PrismWorldInformationRequestMessage(bool join)
        {
            this.join = join;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteBoolean(join);
            

}

public override void Deserialize(IDataReader reader)
{

join = reader.ReadBoolean();
            

}


}


}