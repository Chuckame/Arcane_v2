


















// Generated on 05/16/2016 23:27:32
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class ZaapListMessage : TeleportDestinationsListMessage
{

public new const uint Id = 1604;
public override uint MessageId
{
    get { return Id; }
}

public int spawnMapId;
        

public ZaapListMessage()
{
}

public ZaapListMessage(sbyte teleporterType, int[] mapIds, short[] subAreaIds, short[] costs, int spawnMapId)
         : base(teleporterType, mapIds, subAreaIds, costs)
        {
            this.spawnMapId = spawnMapId;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteInt(spawnMapId);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            spawnMapId = reader.ReadInt();
            if (spawnMapId < 0)
                throw new Exception("Forbidden value on spawnMapId = " + spawnMapId + ", it doesn't respect the following condition : spawnMapId < 0");
            

}


}


}