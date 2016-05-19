


















// Generated on 05/16/2016 23:27:31
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class SpouseStatusMessage : AbstractMessage
{

public const uint Id = 6265;
public override uint MessageId
{
    get { return Id; }
}

public bool hasSpouse;
        

public SpouseStatusMessage()
{
}

public SpouseStatusMessage(bool hasSpouse)
        {
            this.hasSpouse = hasSpouse;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteBoolean(hasSpouse);
            

}

public override void Deserialize(IDataReader reader)
{

hasSpouse = reader.ReadBoolean();
            

}


}


}