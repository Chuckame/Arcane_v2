


















// Generated on 05/16/2016 23:27:32
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class SetCharacterRestrictionsMessage : AbstractMessage
{

public const uint Id = 170;
public override uint MessageId
{
    get { return Id; }
}

public Types.ActorRestrictionsInformations restrictions;
        

public SetCharacterRestrictionsMessage()
{
}

public SetCharacterRestrictionsMessage(Types.ActorRestrictionsInformations restrictions)
        {
            this.restrictions = restrictions;
        }
        

public override void Serialize(IDataWriter writer)
{

restrictions.Serialize(writer);
            

}

public override void Deserialize(IDataReader reader)
{

restrictions = new Types.ActorRestrictionsInformations();
            restrictions.Deserialize(reader);
            

}


}


}