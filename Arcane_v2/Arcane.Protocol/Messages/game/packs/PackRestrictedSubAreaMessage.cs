


















// Generated on 05/16/2016 23:27:35
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class PackRestrictedSubAreaMessage : AbstractMessage
{

public const uint Id = 6186;
public override uint MessageId
{
    get { return Id; }
}

public int subAreaId;
        

public PackRestrictedSubAreaMessage()
{
}

public PackRestrictedSubAreaMessage(int subAreaId)
        {
            this.subAreaId = subAreaId;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(subAreaId);
            

}

public override void Deserialize(IDataReader reader)
{

subAreaId = reader.ReadInt();
            if (subAreaId < 0)
                throw new Exception("Forbidden value on subAreaId = " + subAreaId + ", it doesn't respect the following condition : subAreaId < 0");
            

}


}


}