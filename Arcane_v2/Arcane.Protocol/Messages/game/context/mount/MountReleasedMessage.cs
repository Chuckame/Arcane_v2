


















// Generated on 05/16/2016 23:27:26
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class MountReleasedMessage : AbstractMessage
{

public const uint Id = 6308;
public override uint MessageId
{
    get { return Id; }
}

public double mountId;
        

public MountReleasedMessage()
{
}

public MountReleasedMessage(double mountId)
        {
            this.mountId = mountId;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteDouble(mountId);
            

}

public override void Deserialize(IDataReader reader)
{

mountId = reader.ReadDouble();
            

}


}


}