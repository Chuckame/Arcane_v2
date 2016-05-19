


















// Generated on 05/16/2016 23:27:23
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class GameActionFightTackledMessage : AbstractGameActionMessage
{

public new const uint Id = 1004;
public override uint MessageId
{
    get { return Id; }
}

public int[] tacklersIds;
        

public GameActionFightTackledMessage()
{
}

public GameActionFightTackledMessage(short actionId, int sourceId, int[] tacklersIds)
         : base(actionId, sourceId)
        {
            this.tacklersIds = tacklersIds;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteUShort((ushort)tacklersIds.Length);
            foreach (var entry in tacklersIds)
            {
                 writer.WriteInt(entry);
            }
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            var limit = reader.ReadUShort();
            tacklersIds = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 tacklersIds[i] = reader.ReadInt();
            }
            

}


}


}