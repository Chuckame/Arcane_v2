


















// Generated on 05/16/2016 23:27:24
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class BasicSwitchModeRequestMessage : AbstractMessage
{

public const uint Id = 6101;
public override uint MessageId
{
    get { return Id; }
}

public sbyte mode;
        

public BasicSwitchModeRequestMessage()
{
}

public BasicSwitchModeRequestMessage(sbyte mode)
        {
            this.mode = mode;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteSByte(mode);
            

}

public override void Deserialize(IDataReader reader)
{

mode = reader.ReadSByte();
            

}


}


}