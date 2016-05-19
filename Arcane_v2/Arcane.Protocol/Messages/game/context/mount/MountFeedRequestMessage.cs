


















// Generated on 05/16/2016 23:27:26
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class MountFeedRequestMessage : AbstractMessage
{

public const uint Id = 6189;
public override uint MessageId
{
    get { return Id; }
}

public double mountUid;
        public sbyte mountLocation;
        public int mountFoodUid;
        public int quantity;
        

public MountFeedRequestMessage()
{
}

public MountFeedRequestMessage(double mountUid, sbyte mountLocation, int mountFoodUid, int quantity)
        {
            this.mountUid = mountUid;
            this.mountLocation = mountLocation;
            this.mountFoodUid = mountFoodUid;
            this.quantity = quantity;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteDouble(mountUid);
            writer.WriteSByte(mountLocation);
            writer.WriteInt(mountFoodUid);
            writer.WriteInt(quantity);
            

}

public override void Deserialize(IDataReader reader)
{

mountUid = reader.ReadDouble();
            if (mountUid < 0)
                throw new Exception("Forbidden value on mountUid = " + mountUid + ", it doesn't respect the following condition : mountUid < 0");
            mountLocation = reader.ReadSByte();
            mountFoodUid = reader.ReadInt();
            if (mountFoodUid < 0)
                throw new Exception("Forbidden value on mountFoodUid = " + mountFoodUid + ", it doesn't respect the following condition : mountFoodUid < 0");
            quantity = reader.ReadInt();
            if (quantity < 0)
                throw new Exception("Forbidden value on quantity = " + quantity + ", it doesn't respect the following condition : quantity < 0");
            

}


}


}