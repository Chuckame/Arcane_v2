


















// Generated on 05/16/2016 23:27:28
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class LockableStateUpdateHouseDoorMessage : LockableStateUpdateAbstractMessage
{

public new const uint Id = 5668;
public override uint MessageId
{
    get { return Id; }
}

public int houseId;
        

public LockableStateUpdateHouseDoorMessage()
{
}

public LockableStateUpdateHouseDoorMessage(bool locked, int houseId)
         : base(locked)
        {
            this.houseId = houseId;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteInt(houseId);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            houseId = reader.ReadInt();
            

}


}


}