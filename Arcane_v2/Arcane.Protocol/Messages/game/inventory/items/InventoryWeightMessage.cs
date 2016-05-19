


















// Generated on 05/16/2016 23:27:35
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class InventoryWeightMessage : AbstractMessage
{

public const uint Id = 3009;
public override uint MessageId
{
    get { return Id; }
}

public int weight;
        public int weightMax;
        

public InventoryWeightMessage()
{
}

public InventoryWeightMessage(int weight, int weightMax)
        {
            this.weight = weight;
            this.weightMax = weightMax;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(weight);
            writer.WriteInt(weightMax);
            

}

public override void Deserialize(IDataReader reader)
{

weight = reader.ReadInt();
            if (weight < 0)
                throw new Exception("Forbidden value on weight = " + weight + ", it doesn't respect the following condition : weight < 0");
            weightMax = reader.ReadInt();
            if (weightMax < 0)
                throw new Exception("Forbidden value on weightMax = " + weightMax + ", it doesn't respect the following condition : weightMax < 0");
            

}


}


}