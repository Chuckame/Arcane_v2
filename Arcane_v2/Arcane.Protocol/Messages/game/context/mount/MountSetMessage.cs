


















// Generated on 05/16/2016 23:27:27
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class MountSetMessage : AbstractMessage
{

public const uint Id = 5968;
public override uint MessageId
{
    get { return Id; }
}

public Types.MountClientData mountData;
        

public MountSetMessage()
{
}

public MountSetMessage(Types.MountClientData mountData)
        {
            this.mountData = mountData;
        }
        

public override void Serialize(IDataWriter writer)
{

mountData.Serialize(writer);
            

}

public override void Deserialize(IDataReader reader)
{

mountData = new Types.MountClientData();
            mountData.Deserialize(reader);
            

}


}


}