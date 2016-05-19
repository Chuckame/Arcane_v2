


















// Generated on 05/16/2016 23:27:31
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class FriendDeleteRequestMessage : AbstractMessage
{

public const uint Id = 5603;
public override uint MessageId
{
    get { return Id; }
}

public string name;
        

public FriendDeleteRequestMessage()
{
}

public FriendDeleteRequestMessage(string name)
        {
            this.name = name;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteUTF(name);
            

}

public override void Deserialize(IDataReader reader)
{

name = reader.ReadUTF();
            

}


}


}