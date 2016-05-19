


















// Generated on 05/16/2016 23:27:24
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class NumericWhoIsMessage : AbstractMessage
{

public const uint Id = 6297;
public override uint MessageId
{
    get { return Id; }
}

public int playerId;
        public int accountId;
        

public NumericWhoIsMessage()
{
}

public NumericWhoIsMessage(int playerId, int accountId)
        {
            this.playerId = playerId;
            this.accountId = accountId;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(playerId);
            writer.WriteInt(accountId);
            

}

public override void Deserialize(IDataReader reader)
{

playerId = reader.ReadInt();
            if (playerId < 0)
                throw new Exception("Forbidden value on playerId = " + playerId + ", it doesn't respect the following condition : playerId < 0");
            accountId = reader.ReadInt();
            if (accountId < 0)
                throw new Exception("Forbidden value on accountId = " + accountId + ", it doesn't respect the following condition : accountId < 0");
            

}


}


}