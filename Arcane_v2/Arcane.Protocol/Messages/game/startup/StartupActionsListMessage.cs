


















// Generated on 05/16/2016 23:27:36
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class StartupActionsListMessage : AbstractMessage
{

public const uint Id = 1301;
public override uint MessageId
{
    get { return Id; }
}

public Types.StartupActionAddObject[] actions;
        

public StartupActionsListMessage()
{
}

public StartupActionsListMessage(Types.StartupActionAddObject[] actions)
        {
            this.actions = actions;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteUShort((ushort)actions.Length);
            foreach (var entry in actions)
            {
                 entry.Serialize(writer);
            }
            

}

public override void Deserialize(IDataReader reader)
{

var limit = reader.ReadUShort();
            actions = new Types.StartupActionAddObject[limit];
            for (int i = 0; i < limit; i++)
            {
                 actions[i] = new Types.StartupActionAddObject();
                 actions[i].Deserialize(reader);
            }
            

}


}


}