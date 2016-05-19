


















// Generated on 05/16/2016 23:27:22
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class AcquaintanceSearchMessage : AbstractMessage
{

public const uint Id = 6144;
public override uint MessageId
{
    get { return Id; }
}

public string nickname;
        

public AcquaintanceSearchMessage()
{
}

public AcquaintanceSearchMessage(string nickname)
        {
            this.nickname = nickname;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteUTF(nickname);
            

}

public override void Deserialize(IDataReader reader)
{

nickname = reader.ReadUTF();
            

}


}


}