


















// Generated on 05/16/2016 23:27:39
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class IgnoredInformations : AbstractContactInformations
{

public new const short Id = 106;
public override short TypeId { get { return Id; } }



public IgnoredInformations()
{
}

public IgnoredInformations(int accountId, string accountName)
         : base(accountId, accountName)
        {
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            

}


}


}