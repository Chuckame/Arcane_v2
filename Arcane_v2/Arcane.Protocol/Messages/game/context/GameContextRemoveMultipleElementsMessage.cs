


















// Generated on 05/16/2016 23:27:25
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class GameContextRemoveMultipleElementsMessage : AbstractMessage
{

public const uint Id = 252;
public override uint MessageId
{
    get { return Id; }
}

public int[] id;
        

public GameContextRemoveMultipleElementsMessage()
{
}

public GameContextRemoveMultipleElementsMessage(int[] id)
        {
            this.id = id;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteUShort((ushort)id.Length);
            foreach (var entry in id)
            {
                 writer.WriteInt(entry);
            }
            

}

public override void Deserialize(IDataReader reader)
{

var limit = reader.ReadUShort();
            id = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 id[i] = reader.ReadInt();
            }
            

}


}


}