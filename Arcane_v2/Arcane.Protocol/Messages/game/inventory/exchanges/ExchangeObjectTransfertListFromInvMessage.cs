


















// Generated on 05/16/2016 23:27:33
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class ExchangeObjectTransfertListFromInvMessage : AbstractMessage
{

public const uint Id = 6183;
public override uint MessageId
{
    get { return Id; }
}

public int[] ids;
        

public ExchangeObjectTransfertListFromInvMessage()
{
}

public ExchangeObjectTransfertListFromInvMessage(int[] ids)
        {
            this.ids = ids;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteUShort((ushort)ids.Length);
            foreach (var entry in ids)
            {
                 writer.WriteInt(entry);
            }
            

}

public override void Deserialize(IDataReader reader)
{

var limit = reader.ReadUShort();
            ids = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 ids[i] = reader.ReadInt();
            }
            

}


}


}