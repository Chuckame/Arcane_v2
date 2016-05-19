


















// Generated on 05/16/2016 23:27:35
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class LivingObjectMessageMessage : AbstractMessage
{

public const uint Id = 6065;
public override uint MessageId
{
    get { return Id; }
}

public short msgId;
        public uint timeStamp;
        public string owner;
        public uint objectGenericId;
        

public LivingObjectMessageMessage()
{
}

public LivingObjectMessageMessage(short msgId, uint timeStamp, string owner, uint objectGenericId)
        {
            this.msgId = msgId;
            this.timeStamp = timeStamp;
            this.owner = owner;
            this.objectGenericId = objectGenericId;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteShort(msgId);
            writer.WriteUInt(timeStamp);
            writer.WriteUTF(owner);
            writer.WriteUInt(objectGenericId);
            

}

public override void Deserialize(IDataReader reader)
{

msgId = reader.ReadShort();
            if (msgId < 0)
                throw new Exception("Forbidden value on msgId = " + msgId + ", it doesn't respect the following condition : msgId < 0");
            timeStamp = reader.ReadUInt();
            if (timeStamp < 0 || timeStamp > 4.294967295E9)
                throw new Exception("Forbidden value on timeStamp = " + timeStamp + ", it doesn't respect the following condition : timeStamp < 0 || timeStamp > 4.294967295E9");
            owner = reader.ReadUTF();
            objectGenericId = reader.ReadUInt();
            if (objectGenericId < 0 || objectGenericId > 4.294967295E9)
                throw new Exception("Forbidden value on objectGenericId = " + objectGenericId + ", it doesn't respect the following condition : objectGenericId < 0 || objectGenericId > 4.294967295E9");
            

}


}


}