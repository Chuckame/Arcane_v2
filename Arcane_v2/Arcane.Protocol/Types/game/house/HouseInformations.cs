


















// Generated on 05/16/2016 23:27:39
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class HouseInformations : AbstractType
{

public const short Id = 111;
public override short TypeId { get { return Id; } }

public bool isOnSale;
        public bool isSaleLocked;
        public int houseId;
        public int[] doorsOnMap;
        public string ownerName;
        public short modelId;
        

public HouseInformations()
{
}

public HouseInformations(bool isOnSale, bool isSaleLocked, int houseId, int[] doorsOnMap, string ownerName, short modelId)
        {
            this.isOnSale = isOnSale;
            this.isSaleLocked = isSaleLocked;
            this.houseId = houseId;
            this.doorsOnMap = doorsOnMap;
            this.ownerName = ownerName;
            this.modelId = modelId;
        }
        

public override void Serialize(IDataWriter writer)
{

byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, isOnSale);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, isSaleLocked);
            writer.WriteByte(flag1);
            writer.WriteInt(houseId);
            writer.WriteUShort((ushort)doorsOnMap.Length);
            foreach (var entry in doorsOnMap)
            {
                 writer.WriteInt(entry);
            }
            writer.WriteUTF(ownerName);
            writer.WriteShort(modelId);
            

}

public override void Deserialize(IDataReader reader)
{

byte flag1 = reader.ReadByte();
            isOnSale = BooleanByteWrapper.GetFlag(flag1, 0);
            isSaleLocked = BooleanByteWrapper.GetFlag(flag1, 1);
            houseId = reader.ReadInt();
            if (houseId < 0)
                throw new Exception("Forbidden value on houseId = " + houseId + ", it doesn't respect the following condition : houseId < 0");
            var limit = reader.ReadUShort();
            doorsOnMap = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 doorsOnMap[i] = reader.ReadInt();
            }
            ownerName = reader.ReadUTF();
            modelId = reader.ReadShort();
            if (modelId < 0)
                throw new Exception("Forbidden value on modelId = " + modelId + ", it doesn't respect the following condition : modelId < 0");
            

}


}


}