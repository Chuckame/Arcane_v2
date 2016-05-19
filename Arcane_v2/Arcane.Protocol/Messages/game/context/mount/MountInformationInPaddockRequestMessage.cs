


















// Generated on 05/16/2016 23:27:26
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class MountInformationInPaddockRequestMessage : AbstractMessage
{

public const uint Id = 5975;
public override uint MessageId
{
    get { return Id; }
}

public int mapRideId;
        

public MountInformationInPaddockRequestMessage()
{
}

public MountInformationInPaddockRequestMessage(int mapRideId)
        {
            this.mapRideId = mapRideId;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(mapRideId);
            

}

public override void Deserialize(IDataReader reader)
{

mapRideId = reader.ReadInt();
            

}


}


}