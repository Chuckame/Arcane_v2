


















// Generated on 05/16/2016 23:27:36
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class PrismFightSwapRequestMessage : AbstractMessage
{

public const uint Id = 5901;
public override uint MessageId
{
    get { return Id; }
}

public int targetId;
        

public PrismFightSwapRequestMessage()
{
}

public PrismFightSwapRequestMessage(int targetId)
        {
            this.targetId = targetId;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(targetId);
            

}

public override void Deserialize(IDataReader reader)
{

targetId = reader.ReadInt();
            if (targetId < 0)
                throw new Exception("Forbidden value on targetId = " + targetId + ", it doesn't respect the following condition : targetId < 0");
            

}


}


}