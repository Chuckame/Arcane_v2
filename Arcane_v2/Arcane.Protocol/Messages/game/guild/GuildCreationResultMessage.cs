


















// Generated on 05/16/2016 23:27:31
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class GuildCreationResultMessage : AbstractMessage
{

public const uint Id = 5554;
public override uint MessageId
{
    get { return Id; }
}

public sbyte result;
        

public GuildCreationResultMessage()
{
}

public GuildCreationResultMessage(sbyte result)
        {
            this.result = result;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteSByte(result);
            

}

public override void Deserialize(IDataReader reader)
{

result = reader.ReadSByte();
            if (result < 0)
                throw new Exception("Forbidden value on result = " + result + ", it doesn't respect the following condition : result < 0");
            

}


}


}