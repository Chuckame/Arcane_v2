


















// Generated on 05/16/2016 23:27:28
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class NpcDialogCreationMessage : AbstractMessage
{

public const uint Id = 5618;
public override uint MessageId
{
    get { return Id; }
}

public int mapId;
        public int npcId;
        

public NpcDialogCreationMessage()
{
}

public NpcDialogCreationMessage(int mapId, int npcId)
        {
            this.mapId = mapId;
            this.npcId = npcId;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(mapId);
            writer.WriteInt(npcId);
            

}

public override void Deserialize(IDataReader reader)
{

mapId = reader.ReadInt();
            npcId = reader.ReadInt();
            

}


}


}