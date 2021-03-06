


















// Generated on 05/16/2016 23:27:37
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class DownloadSetSpeedRequestMessage : AbstractMessage
{

public const uint Id = 1512;
public override uint MessageId
{
    get { return Id; }
}

public sbyte downloadSpeed;
        

public DownloadSetSpeedRequestMessage()
{
}

public DownloadSetSpeedRequestMessage(sbyte downloadSpeed)
        {
            this.downloadSpeed = downloadSpeed;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteSByte(downloadSpeed);
            

}

public override void Deserialize(IDataReader reader)
{

downloadSpeed = reader.ReadSByte();
            if (downloadSpeed < 1 || downloadSpeed > 10)
                throw new Exception("Forbidden value on downloadSpeed = " + downloadSpeed + ", it doesn't respect the following condition : downloadSpeed < 1 || downloadSpeed > 10");
            

}


}


}