


















// Generated on 05/16/2016 23:27:25
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class GameContextCreateMessage : AbstractMessage
{

public const uint Id = 200;
public override uint MessageId
{
    get { return Id; }
}

public sbyte context;
        

public GameContextCreateMessage()
{
}

public GameContextCreateMessage(sbyte context)
        {
            this.context = context;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteSByte(context);
            

}

public override void Deserialize(IDataReader reader)
{

context = reader.ReadSByte();
            if (context < 0)
                throw new Exception("Forbidden value on context = " + context + ", it doesn't respect the following condition : context < 0");
            

}


}


}