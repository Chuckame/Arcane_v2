


















// Generated on 05/16/2016 23:27:36
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class AlignmentSubAreasListMessage : AbstractMessage
{

public const uint Id = 6059;
public override uint MessageId
{
    get { return Id; }
}

public short[] angelsSubAreas;
        public short[] evilsSubAreas;
        

public AlignmentSubAreasListMessage()
{
}

public AlignmentSubAreasListMessage(short[] angelsSubAreas, short[] evilsSubAreas)
        {
            this.angelsSubAreas = angelsSubAreas;
            this.evilsSubAreas = evilsSubAreas;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteUShort((ushort)angelsSubAreas.Length);
            foreach (var entry in angelsSubAreas)
            {
                 writer.WriteShort(entry);
            }
            writer.WriteUShort((ushort)evilsSubAreas.Length);
            foreach (var entry in evilsSubAreas)
            {
                 writer.WriteShort(entry);
            }
            

}

public override void Deserialize(IDataReader reader)
{

var limit = reader.ReadUShort();
            angelsSubAreas = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 angelsSubAreas[i] = reader.ReadShort();
            }
            limit = reader.ReadUShort();
            evilsSubAreas = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 evilsSubAreas[i] = reader.ReadShort();
            }
            

}


}


}