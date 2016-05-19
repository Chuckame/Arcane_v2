


















// Generated on 05/16/2016 23:27:29
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class DungeonPartyFinderAvailableDungeonsMessage : AbstractMessage
{

public const uint Id = 6242;
public override uint MessageId
{
    get { return Id; }
}

public short[] dungeonIds;
        

public DungeonPartyFinderAvailableDungeonsMessage()
{
}

public DungeonPartyFinderAvailableDungeonsMessage(short[] dungeonIds)
        {
            this.dungeonIds = dungeonIds;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteUShort((ushort)dungeonIds.Length);
            foreach (var entry in dungeonIds)
            {
                 writer.WriteShort(entry);
            }
            

}

public override void Deserialize(IDataReader reader)
{

var limit = reader.ReadUShort();
            dungeonIds = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 dungeonIds[i] = reader.ReadShort();
            }
            

}


}


}