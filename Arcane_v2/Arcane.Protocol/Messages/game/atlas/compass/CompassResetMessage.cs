


















// Generated on 05/16/2016 23:27:23
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class CompassResetMessage : AbstractMessage
{

public const uint Id = 5584;
public override uint MessageId
{
    get { return Id; }
}

public sbyte type;
        

public CompassResetMessage()
{
}

public CompassResetMessage(sbyte type)
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
            if (type < 0)
                throw new Exception("Forbidden value on type = " + type + ", it doesn't respect the following condition : type < 0");
            

}


}


}