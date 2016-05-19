


















// Generated on 05/16/2016 23:27:34
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class ExchangeStartOkJobIndexMessage : AbstractMessage
{

public const uint Id = 5819;
public override uint MessageId
{
    get { return Id; }
}

public int[] jobs;
        

public ExchangeStartOkJobIndexMessage()
{
}

public ExchangeStartOkJobIndexMessage(int[] jobs)
        {
            this.jobs = jobs;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteUShort((ushort)jobs.Length);
            foreach (var entry in jobs)
            {
                 writer.WriteInt(entry);
            }
            

}

public override void Deserialize(IDataReader reader)
{

var limit = reader.ReadUShort();
            jobs = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 jobs[i] = reader.ReadInt();
            }
            

}


}


}