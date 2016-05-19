


















// Generated on 05/16/2016 23:27:32
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class ExchangeBidHouseBuyResultMessage : AbstractMessage
{

public const uint Id = 6272;
public override uint MessageId
{
    get { return Id; }
}

public int uid;
        public bool bought;
        

public ExchangeBidHouseBuyResultMessage()
{
}

public ExchangeBidHouseBuyResultMessage(int uid, bool bought)
        {
            this.uid = uid;
            this.bought = bought;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(uid);
            writer.WriteBoolean(bought);
            

}

public override void Deserialize(IDataReader reader)
{

uid = reader.ReadInt();
            if (uid < 0)
                throw new Exception("Forbidden value on uid = " + uid + ", it doesn't respect the following condition : uid < 0");
            bought = reader.ReadBoolean();
            

}


}


}