


















// Generated on 05/16/2016 23:27:29
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class GameDataPlayFarmObjectAnimationMessage : AbstractMessage
{

public const uint Id = 6026;
public override uint MessageId
{
    get { return Id; }
}

public short[] cellId;
        

public GameDataPlayFarmObjectAnimationMessage()
{
}

public GameDataPlayFarmObjectAnimationMessage(short[] cellId)
        {
            this.cellId = cellId;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteUShort((ushort)cellId.Length);
            foreach (var entry in cellId)
            {
                 writer.WriteShort(entry);
            }
            

}

public override void Deserialize(IDataReader reader)
{

var limit = reader.ReadUShort();
            cellId = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 cellId[i] = reader.ReadShort();
            }
            

}


}


}