


















// Generated on 05/16/2016 23:27:39
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class PrismSubAreaInformation : AbstractType
{

public const short Id = 142;
public override short TypeId { get { return Id; } }

public short worldX;
        public short worldY;
        public int mapId;
        public short subAreaId;
        public sbyte alignment;
        public bool isInFight;
        public bool isFightable;
        

public PrismSubAreaInformation()
{
}

public PrismSubAreaInformation(short worldX, short worldY, int mapId, short subAreaId, sbyte alignment, bool isInFight, bool isFightable)
        {
            this.worldX = worldX;
            this.worldY = worldY;
            this.mapId = mapId;
            this.subAreaId = subAreaId;
            this.alignment = alignment;
            this.isInFight = isInFight;
            this.isFightable = isFightable;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteShort(worldX);
            writer.WriteShort(worldY);
            writer.WriteInt(mapId);
            writer.WriteShort(subAreaId);
            writer.WriteSByte(alignment);
            writer.WriteBoolean(isInFight);
            writer.WriteBoolean(isFightable);
            

}

public override void Deserialize(IDataReader reader)
{

worldX = reader.ReadShort();
            if (worldX < -255 || worldX > 255)
                throw new Exception("Forbidden value on worldX = " + worldX + ", it doesn't respect the following condition : worldX < -255 || worldX > 255");
            worldY = reader.ReadShort();
            if (worldY < -255 || worldY > 255)
                throw new Exception("Forbidden value on worldY = " + worldY + ", it doesn't respect the following condition : worldY < -255 || worldY > 255");
            mapId = reader.ReadInt();
            subAreaId = reader.ReadShort();
            if (subAreaId < 0)
                throw new Exception("Forbidden value on subAreaId = " + subAreaId + ", it doesn't respect the following condition : subAreaId < 0");
            alignment = reader.ReadSByte();
            if (alignment < 0)
                throw new Exception("Forbidden value on alignment = " + alignment + ", it doesn't respect the following condition : alignment < 0");
            isInFight = reader.ReadBoolean();
            isFightable = reader.ReadBoolean();
            

}


}


}