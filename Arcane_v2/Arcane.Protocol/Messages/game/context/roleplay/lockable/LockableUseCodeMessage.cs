


















// Generated on 05/16/2016 23:27:28
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class LockableUseCodeMessage : AbstractMessage
{

public const uint Id = 5667;
public override uint MessageId
{
    get { return Id; }
}

public string code;
        

public LockableUseCodeMessage()
{
}

public LockableUseCodeMessage(string code)
        {
            this.code = code;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteUTF(code);
            

}

public override void Deserialize(IDataReader reader)
{

code = reader.ReadUTF();
            

}


}


}