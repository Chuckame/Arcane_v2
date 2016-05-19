


















// Generated on 05/16/2016 23:27:28
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class HouseLockFromInsideRequestMessage : LockableChangeCodeMessage
{

public new const uint Id = 5885;
public override uint MessageId
{
    get { return Id; }
}



public HouseLockFromInsideRequestMessage()
{
}

public HouseLockFromInsideRequestMessage(string code)
         : base(code)
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