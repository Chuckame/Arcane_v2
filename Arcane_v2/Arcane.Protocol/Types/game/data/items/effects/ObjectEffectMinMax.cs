


















// Generated on 05/16/2016 23:27:39
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class ObjectEffectMinMax : ObjectEffect
{

public new const short Id = 82;
public override short TypeId { get { return Id; } }

public short min;
        public short max;
        

public ObjectEffectMinMax()
{
}

public ObjectEffectMinMax(short actionId, short min, short max)
         : base(actionId)
        {
            this.min = min;
            this.max = max;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteShort(min);
            writer.WriteShort(max);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            min = reader.ReadShort();
            if (min < 0)
                throw new Exception("Forbidden value on min = " + min + ", it doesn't respect the following condition : min < 0");
            max = reader.ReadShort();
            if (max < 0)
                throw new Exception("Forbidden value on max = " + max + ", it doesn't respect the following condition : max < 0");
            

}


}


}