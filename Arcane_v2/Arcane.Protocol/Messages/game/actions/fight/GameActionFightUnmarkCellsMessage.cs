


















// Generated on 05/16/2016 23:27:23
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class GameActionFightUnmarkCellsMessage : AbstractGameActionMessage
{

public new const uint Id = 5570;
public override uint MessageId
{
    get { return Id; }
}

public short markId;
        

public GameActionFightUnmarkCellsMessage()
{
}

public GameActionFightUnmarkCellsMessage(short actionId, int sourceId, short markId)
         : base(actionId, sourceId)
        {
            this.markId = markId;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteShort(markId);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            markId = reader.ReadShort();
            

}


}


}