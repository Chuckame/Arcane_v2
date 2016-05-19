


















// Generated on 05/16/2016 23:27:37
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class Achievement : AbstractType
{

public const short Id = 363;
public override short TypeId { get { return Id; } }

public short id;
        

public Achievement()
{
}

public Achievement(short id)
        {
            this.id = id;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteShort(id);
            

}

public override void Deserialize(IDataReader reader)
{

id = reader.ReadShort();
            if (id < 0)
                throw new Exception("Forbidden value on id = " + id + ", it doesn't respect the following condition : id < 0");
            

}


}


}