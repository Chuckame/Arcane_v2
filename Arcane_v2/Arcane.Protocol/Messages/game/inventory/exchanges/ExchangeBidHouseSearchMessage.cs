


















// Generated on 05/16/2016 23:27:32
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class ExchangeBidHouseSearchMessage : AbstractMessage
{

public const uint Id = 5806;
public override uint MessageId
{
    get { return Id; }
}

public int type;
        public int genId;
        

public ExchangeBidHouseSearchMessage()
{
}

public ExchangeBidHouseSearchMessage(int type, int genId)
        {
            this.type = type;
            this.genId = genId;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(type);
            writer.WriteInt(genId);
            

}

public override void Deserialize(IDataReader reader)
{

type = reader.ReadInt();
            if (type < 0)
                throw new Exception("Forbidden value on type = " + type + ", it doesn't respect the following condition : type < 0");
            genId = reader.ReadInt();
            if (genId < 0)
                throw new Exception("Forbidden value on genId = " + genId + ", it doesn't respect the following condition : genId < 0");
            

}


}


}