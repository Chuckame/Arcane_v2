


















// Generated on 05/16/2016 23:27:28
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class HouseGuildShareRequestMessage : AbstractMessage
{

public const uint Id = 5704;
public override uint MessageId
{
    get { return Id; }
}

public bool enable;
        public uint rights;
        

public HouseGuildShareRequestMessage()
{
}

public HouseGuildShareRequestMessage(bool enable, uint rights)
        {
            this.enable = enable;
            this.rights = rights;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteBoolean(enable);
            writer.WriteUInt(rights);
            

}

public override void Deserialize(IDataReader reader)
{

enable = reader.ReadBoolean();
            rights = reader.ReadUInt();
            if (rights < 0 || rights > 4.294967295E9)
                throw new Exception("Forbidden value on rights = " + rights + ", it doesn't respect the following condition : rights < 0 || rights > 4.294967295E9");
            

}


}


}