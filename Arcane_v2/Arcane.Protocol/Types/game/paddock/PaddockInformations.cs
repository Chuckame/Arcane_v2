


















// Generated on 05/16/2016 23:27:39
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class PaddockInformations : AbstractType
{

public const short Id = 132;
public override short TypeId { get { return Id; } }

public short maxOutdoorMount;
        public short maxItems;
        

public PaddockInformations()
{
}

public PaddockInformations(short maxOutdoorMount, short maxItems)
        {
            this.maxOutdoorMount = maxOutdoorMount;
            this.maxItems = maxItems;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteShort(maxOutdoorMount);
            writer.WriteShort(maxItems);
            

}

public override void Deserialize(IDataReader reader)
{

maxOutdoorMount = reader.ReadShort();
            if (maxOutdoorMount < 0)
                throw new Exception("Forbidden value on maxOutdoorMount = " + maxOutdoorMount + ", it doesn't respect the following condition : maxOutdoorMount < 0");
            maxItems = reader.ReadShort();
            if (maxItems < 0)
                throw new Exception("Forbidden value on maxItems = " + maxItems + ", it doesn't respect the following condition : maxItems < 0");
            

}


}


}