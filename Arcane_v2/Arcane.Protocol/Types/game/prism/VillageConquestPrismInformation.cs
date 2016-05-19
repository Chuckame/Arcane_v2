


















// Generated on 05/16/2016 23:27:39
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class VillageConquestPrismInformation : AbstractType
{

public const short Id = 379;
public override short TypeId { get { return Id; } }

public bool isEntered;
        public bool isInRoom;
        public short areaId;
        public sbyte areaAlignment;
        

public VillageConquestPrismInformation()
{
}

public VillageConquestPrismInformation(bool isEntered, bool isInRoom, short areaId, sbyte areaAlignment)
        {
            this.isEntered = isEntered;
            this.isInRoom = isInRoom;
            this.areaId = areaId;
            this.areaAlignment = areaAlignment;
        }
        

public override void Serialize(IDataWriter writer)
{

byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, isEntered);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, isInRoom);
            writer.WriteByte(flag1);
            writer.WriteShort(areaId);
            writer.WriteSByte(areaAlignment);
            

}

public override void Deserialize(IDataReader reader)
{

byte flag1 = reader.ReadByte();
            isEntered = BooleanByteWrapper.GetFlag(flag1, 0);
            isInRoom = BooleanByteWrapper.GetFlag(flag1, 1);
            areaId = reader.ReadShort();
            if (areaId < 0)
                throw new Exception("Forbidden value on areaId = " + areaId + ", it doesn't respect the following condition : areaId < 0");
            areaAlignment = reader.ReadSByte();
            if (areaAlignment < 0)
                throw new Exception("Forbidden value on areaAlignment = " + areaAlignment + ", it doesn't respect the following condition : areaAlignment < 0");
            

}


}


}