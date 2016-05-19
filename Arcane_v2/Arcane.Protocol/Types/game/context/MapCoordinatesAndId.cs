


















// Generated on 05/16/2016 23:27:37
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class MapCoordinatesAndId : MapCoordinates
{

public new const short Id = 392;
public override short TypeId { get { return Id; } }

public int mapId;
        

public MapCoordinatesAndId()
{
}

public MapCoordinatesAndId(short worldX, short worldY, int mapId)
         : base(worldX, worldY)
        {
            this.mapId = mapId;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteInt(mapId);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            mapId = reader.ReadInt();
            

}


}


}