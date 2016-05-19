


















// Generated on 05/16/2016 23:27:25
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class DisplayNumericalValueMessage : AbstractMessage
{

public const uint Id = 5808;
public override uint MessageId
{
    get { return Id; }
}

public int entityId;
        public int value;
        public sbyte type;
        

public DisplayNumericalValueMessage()
{
}

public DisplayNumericalValueMessage(int entityId, int value, sbyte type)
        {
            this.entityId = entityId;
            this.value = value;
            this.type = type;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(entityId);
            writer.WriteInt(value);
            writer.WriteSByte(type);
            

}

public override void Deserialize(IDataReader reader)
{

entityId = reader.ReadInt();
            value = reader.ReadInt();
            type = reader.ReadSByte();
            if (type < 0)
                throw new Exception("Forbidden value on type = " + type + ", it doesn't respect the following condition : type < 0");
            

}


}


}