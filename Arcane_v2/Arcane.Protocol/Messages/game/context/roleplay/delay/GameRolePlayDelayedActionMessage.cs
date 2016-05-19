


















// Generated on 05/16/2016 23:27:27
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class GameRolePlayDelayedActionMessage : AbstractMessage
{

public const uint Id = 6153;
public override uint MessageId
{
    get { return Id; }
}

public int delayedCharacterId;
        public sbyte delayTypeId;
        public int delayDuration;
        

public GameRolePlayDelayedActionMessage()
{
}

public GameRolePlayDelayedActionMessage(int delayedCharacterId, sbyte delayTypeId, int delayDuration)
        {
            this.delayedCharacterId = delayedCharacterId;
            this.delayTypeId = delayTypeId;
            this.delayDuration = delayDuration;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(delayedCharacterId);
            writer.WriteSByte(delayTypeId);
            writer.WriteInt(delayDuration);
            

}

public override void Deserialize(IDataReader reader)
{

delayedCharacterId = reader.ReadInt();
            delayTypeId = reader.ReadSByte();
            if (delayTypeId < 0)
                throw new Exception("Forbidden value on delayTypeId = " + delayTypeId + ", it doesn't respect the following condition : delayTypeId < 0");
            delayDuration = reader.ReadInt();
            if (delayDuration < 0)
                throw new Exception("Forbidden value on delayDuration = " + delayDuration + ", it doesn't respect the following condition : delayDuration < 0");
            

}


}


}