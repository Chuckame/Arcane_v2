


















// Generated on 05/16/2016 23:27:31
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class IgnoredListMessage : AbstractMessage
{

public const uint Id = 5674;
public override uint MessageId
{
    get { return Id; }
}

public Types.IgnoredInformations[] ignoredList;
        

public IgnoredListMessage()
{
}

public IgnoredListMessage(Types.IgnoredInformations[] ignoredList)
        {
            this.ignoredList = ignoredList;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteUShort((ushort)ignoredList.Length);
            foreach (var entry in ignoredList)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
            }
            

}

public override void Deserialize(IDataReader reader)
{

var limit = reader.ReadUShort();
            ignoredList = new Types.IgnoredInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 ignoredList[i] = Types.ProtocolTypeManager.GetInstance<Types.IgnoredInformations>(reader.ReadShort());
                 ignoredList[i].Deserialize(reader);
            }
            

}


}


}