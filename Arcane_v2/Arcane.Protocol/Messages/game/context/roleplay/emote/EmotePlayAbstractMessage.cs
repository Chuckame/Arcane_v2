


















// Generated on 05/16/2016 23:27:27
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class EmotePlayAbstractMessage : AbstractMessage
{

public const uint Id = 5690;
public override uint MessageId
{
    get { return Id; }
}

public sbyte emoteId;
        public double emoteStartTime;
        

public EmotePlayAbstractMessage()
{
}

public EmotePlayAbstractMessage(sbyte emoteId, double emoteStartTime)
        {
            this.emoteId = emoteId;
            this.emoteStartTime = emoteStartTime;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteSByte(emoteId);
            writer.WriteDouble(emoteStartTime);
            

}

public override void Deserialize(IDataReader reader)
{

emoteId = reader.ReadSByte();
            if (emoteId < 0)
                throw new Exception("Forbidden value on emoteId = " + emoteId + ", it doesn't respect the following condition : emoteId < 0");
            emoteStartTime = reader.ReadDouble();
            

}


}


}