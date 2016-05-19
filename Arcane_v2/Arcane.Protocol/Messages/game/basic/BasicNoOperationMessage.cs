


















// Generated on 05/16/2016 23:27:24
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class BasicNoOperationMessage : AbstractMessage
{

public const uint Id = 176;
public override uint MessageId
{
    get { return Id; }
}



public BasicNoOperationMessage()
{
}



public override void Serialize(IDataWriter writer)
{



}

public override void Deserialize(IDataReader reader)
{



}


}


}