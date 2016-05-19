


















// Generated on 05/16/2016 23:27:29
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class AbstractPartyMessage : AbstractMessage
{

public const uint Id = 6274;
public override uint MessageId
{
    get { return Id; }
}

public int partyId;
        

public AbstractPartyMessage()
{
}

public AbstractPartyMessage(int partyId)
        {
            this.partyId = partyId;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(partyId);
            

}

public override void Deserialize(IDataReader reader)
{

partyId = reader.ReadInt();
            if (partyId < 0)
                throw new Exception("Forbidden value on partyId = " + partyId + ", it doesn't respect the following condition : partyId < 0");
            

}


}


}