


















// Generated on 05/16/2016 23:27:39
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class MapObstacle : AbstractType
{

public const short Id = 200;
public override short TypeId { get { return Id; } }

public short obstacleCellId;
        public sbyte state;
        

public MapObstacle()
{
}

public MapObstacle(short obstacleCellId, sbyte state)
        {
            this.obstacleCellId = obstacleCellId;
            this.state = state;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteShort(obstacleCellId);
            writer.WriteSByte(state);
            

}

public override void Deserialize(IDataReader reader)
{

obstacleCellId = reader.ReadShort();
            if (obstacleCellId < 0 || obstacleCellId > 559)
                throw new Exception("Forbidden value on obstacleCellId = " + obstacleCellId + ", it doesn't respect the following condition : obstacleCellId < 0 || obstacleCellId > 559");
            state = reader.ReadSByte();
            if (state < 0)
                throw new Exception("Forbidden value on state = " + state + ", it doesn't respect the following condition : state < 0");
            

}


}


}