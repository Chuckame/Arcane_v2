


















// Generated on 05/16/2016 23:27:39
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class AbstractContactInformations : AbstractType
{

public const short Id = 380;
public override short TypeId { get { return Id; } }

public int accountId;
        public string accountName;
        

public AbstractContactInformations()
{
}

public AbstractContactInformations(int accountId, string accountName)
        {
            this.accountId = accountId;
            this.accountName = accountName;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(accountId);
            writer.WriteUTF(accountName);
            

}

public override void Deserialize(IDataReader reader)
{

accountId = reader.ReadInt();
            if (accountId < 0)
                throw new Exception("Forbidden value on accountId = " + accountId + ", it doesn't respect the following condition : accountId < 0");
            accountName = reader.ReadUTF();
            

}


}


}