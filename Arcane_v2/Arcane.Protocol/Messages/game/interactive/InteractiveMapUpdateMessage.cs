


















// Generated on 05/16/2016 23:27:32
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class InteractiveMapUpdateMessage : AbstractMessage
{

public const uint Id = 5002;
public override uint MessageId
{
    get { return Id; }
}

public Types.InteractiveElement[] interactiveElements;
        

public InteractiveMapUpdateMessage()
{
}

public InteractiveMapUpdateMessage(Types.InteractiveElement[] interactiveElements)
        {
            this.interactiveElements = interactiveElements;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteUShort((ushort)interactiveElements.Length);
            foreach (var entry in interactiveElements)
            {
                 entry.Serialize(writer);
            }
            

}

public override void Deserialize(IDataReader reader)
{

var limit = reader.ReadUShort();
            interactiveElements = new Types.InteractiveElement[limit];
            for (int i = 0; i < limit; i++)
            {
                 interactiveElements[i] = new Types.InteractiveElement();
                 interactiveElements[i].Deserialize(reader);
            }
            

}


}


}