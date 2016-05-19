


















// Generated on 05/16/2016 23:27:34
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class GoldAddedMessage : AbstractMessage
{

public const uint Id = 6030;
public override uint MessageId
{
    get { return Id; }
}

public Types.GoldItem gold;
        

public GoldAddedMessage()
{
}

public GoldAddedMessage(Types.GoldItem gold)
        {
            this.gold = gold;
        }
        

public override void Serialize(IDataWriter writer)
{

gold.Serialize(writer);
            

}

public override void Deserialize(IDataReader reader)
{

gold = new Types.GoldItem();
            gold.Deserialize(reader);
            

}


}


}