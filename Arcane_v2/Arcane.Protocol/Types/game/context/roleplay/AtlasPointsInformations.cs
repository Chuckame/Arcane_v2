


















// Generated on 05/16/2016 23:27:38
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class AtlasPointsInformations : AbstractType
{

public const short Id = 175;
public override short TypeId { get { return Id; } }

public sbyte type;
        public Types.MapCoordinatesExtended[] coords;
        

public AtlasPointsInformations()
{
}

public AtlasPointsInformations(sbyte type, Types.MapCoordinatesExtended[] coords)
        {
            this.type = type;
            this.coords = coords;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteSByte(type);
            writer.WriteUShort((ushort)coords.Length);
            foreach (var entry in coords)
            {
                 entry.Serialize(writer);
            }
            

}

public override void Deserialize(IDataReader reader)
{

type = reader.ReadSByte();
            if (type < 0)
                throw new Exception("Forbidden value on type = " + type + ", it doesn't respect the following condition : type < 0");
            var limit = reader.ReadUShort();
            coords = new Types.MapCoordinatesExtended[limit];
            for (int i = 0; i < limit; i++)
            {
                 coords[i] = new Types.MapCoordinatesExtended();
                 coords[i].Deserialize(reader);
            }
            

}


}


}