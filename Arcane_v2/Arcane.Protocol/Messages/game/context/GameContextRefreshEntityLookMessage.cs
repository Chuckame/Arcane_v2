


















// Generated on 05/16/2016 23:27:25
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class GameContextRefreshEntityLookMessage : AbstractMessage
{

public const uint Id = 5637;
public override uint MessageId
{
    get { return Id; }
}

public int id;
        public Types.EntityLook look;
        

public GameContextRefreshEntityLookMessage()
{
}

public GameContextRefreshEntityLookMessage(int id, Types.EntityLook look)
        {
            this.id = id;
            this.look = look;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(id);
            look.Serialize(writer);
            

}

public override void Deserialize(IDataReader reader)
{

id = reader.ReadInt();
            look = new Types.EntityLook();
            look.Deserialize(reader);
            

}


}


}