


















// Generated on 05/16/2016 23:27:34
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class ExchangeTypesExchangerDescriptionForUserMessage : AbstractMessage
{

public const uint Id = 5765;
public override uint MessageId
{
    get { return Id; }
}

public int[] typeDescription;
        

public ExchangeTypesExchangerDescriptionForUserMessage()
{
}

public ExchangeTypesExchangerDescriptionForUserMessage(int[] typeDescription)
        {
            this.typeDescription = typeDescription;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteUShort((ushort)typeDescription.Length);
            foreach (var entry in typeDescription)
            {
                 writer.WriteInt(entry);
            }
            

}

public override void Deserialize(IDataReader reader)
{

var limit = reader.ReadUShort();
            typeDescription = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 typeDescription[i] = reader.ReadInt();
            }
            

}


}


}