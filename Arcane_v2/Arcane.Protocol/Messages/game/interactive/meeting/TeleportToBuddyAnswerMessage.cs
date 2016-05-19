


















// Generated on 05/16/2016 23:27:32
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class TeleportToBuddyAnswerMessage : AbstractMessage
{

public const uint Id = 6293;
public override uint MessageId
{
    get { return Id; }
}

public short dungeonId;
        public int buddyId;
        public bool accept;
        

public TeleportToBuddyAnswerMessage()
{
}

public TeleportToBuddyAnswerMessage(short dungeonId, int buddyId, bool accept)
        {
            this.dungeonId = dungeonId;
            this.buddyId = buddyId;
            this.accept = accept;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteShort(dungeonId);
            writer.WriteInt(buddyId);
            writer.WriteBoolean(accept);
            

}

public override void Deserialize(IDataReader reader)
{

dungeonId = reader.ReadShort();
            if (dungeonId < 0)
                throw new Exception("Forbidden value on dungeonId = " + dungeonId + ", it doesn't respect the following condition : dungeonId < 0");
            buddyId = reader.ReadInt();
            if (buddyId < 0)
                throw new Exception("Forbidden value on buddyId = " + buddyId + ", it doesn't respect the following condition : buddyId < 0");
            accept = reader.ReadBoolean();
            

}


}


}