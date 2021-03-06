


















// Generated on 05/16/2016 23:27:25
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class GameContextMoveMultipleElementsMessage : AbstractMessage
{

public const uint Id = 254;
public override uint MessageId
{
    get { return Id; }
}

public Types.EntityMovementInformations[] movements;
        

public GameContextMoveMultipleElementsMessage()
{
}

public GameContextMoveMultipleElementsMessage(Types.EntityMovementInformations[] movements)
        {
            this.movements = movements;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteUShort((ushort)movements.Length);
            foreach (var entry in movements)
            {
                 entry.Serialize(writer);
            }
            

}

public override void Deserialize(IDataReader reader)
{

var limit = reader.ReadUShort();
            movements = new Types.EntityMovementInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 movements[i] = new Types.EntityMovementInformations();
                 movements[i].Deserialize(reader);
            }
            

}


}


}