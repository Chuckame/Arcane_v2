


















// Generated on 05/16/2016 23:27:23
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class GameActionFightMarkCellsMessage : AbstractGameActionMessage
{

public new const uint Id = 5540;
public override uint MessageId
{
    get { return Id; }
}

public Types.GameActionMark mark;
        

public GameActionFightMarkCellsMessage()
{
}

public GameActionFightMarkCellsMessage(short actionId, int sourceId, Types.GameActionMark mark)
         : base(actionId, sourceId)
        {
            this.mark = mark;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            mark.Serialize(writer);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            mark = new Types.GameActionMark();
            mark.Deserialize(reader);
            

}


}


}