


















// Generated on 05/16/2016 23:27:27
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class CurrentMapMessage : AbstractMessage
{

public const uint Id = 220;
public override uint MessageId
{
    get { return Id; }
}

public int mapId;
        public string mapKey;
        

public CurrentMapMessage()
{
}

public CurrentMapMessage(int mapId, string mapKey)
        {
            this.mapId = mapId;
            this.mapKey = mapKey;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(mapId);
            writer.WriteUTF(mapKey);
            

}

public override void Deserialize(IDataReader reader)
{

mapId = reader.ReadInt();
            if (mapId < 0)
                throw new Exception("Forbidden value on mapId = " + mapId + ", it doesn't respect the following condition : mapId < 0");
            mapKey = reader.ReadUTF();
            

}


}


}