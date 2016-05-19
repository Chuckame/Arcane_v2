


















// Generated on 05/16/2016 23:27:34
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class ExchangeStartOkMountWithOutPaddockMessage : AbstractMessage
{

public const uint Id = 5991;
public override uint MessageId
{
    get { return Id; }
}

public Types.MountClientData[] stabledMountsDescription;
        

public ExchangeStartOkMountWithOutPaddockMessage()
{
}

public ExchangeStartOkMountWithOutPaddockMessage(Types.MountClientData[] stabledMountsDescription)
        {
            this.stabledMountsDescription = stabledMountsDescription;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteUShort((ushort)stabledMountsDescription.Length);
            foreach (var entry in stabledMountsDescription)
            {
                 entry.Serialize(writer);
            }
            

}

public override void Deserialize(IDataReader reader)
{

var limit = reader.ReadUShort();
            stabledMountsDescription = new Types.MountClientData[limit];
            for (int i = 0; i < limit; i++)
            {
                 stabledMountsDescription[i] = new Types.MountClientData();
                 stabledMountsDescription[i].Deserialize(reader);
            }
            

}


}


}