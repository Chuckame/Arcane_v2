


















// Generated on 05/16/2016 23:27:37
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class MapCoordinates : AbstractType
{

public const short Id = 174;
public override short TypeId { get { return Id; } }

public short worldX;
        public short worldY;
        

public MapCoordinates()
{
}

public MapCoordinates(short worldX, short worldY)
        {
            this.worldX = worldX;
            this.worldY = worldY;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteShort(worldX);
            writer.WriteShort(worldY);
            

}

public override void Deserialize(IDataReader reader)
{

worldX = reader.ReadShort();
            if (worldX < -255 || worldX > 255)
                throw new Exception("Forbidden value on worldX = " + worldX + ", it doesn't respect the following condition : worldX < -255 || worldX > 255");
            worldY = reader.ReadShort();
            if (worldY < -255 || worldY > 255)
                throw new Exception("Forbidden value on worldY = " + worldY + ", it doesn't respect the following condition : worldY < -255 || worldY > 255");
            

}


}


}