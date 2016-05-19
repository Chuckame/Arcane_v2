


















// Generated on 05/16/2016 23:27:39
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class UpdateMountBoost : AbstractType
{

public const short Id = 356;
public override short TypeId { get { return Id; } }

public sbyte type;
        

public UpdateMountBoost()
{
}

public UpdateMountBoost(sbyte type)
        {
            this.type = type;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteSByte(type);
            

}

public override void Deserialize(IDataReader reader)
{

type = reader.ReadSByte();
            

}


}


}