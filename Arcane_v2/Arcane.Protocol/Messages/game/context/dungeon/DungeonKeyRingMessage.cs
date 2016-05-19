


















// Generated on 05/16/2016 23:27:25
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class DungeonKeyRingMessage : AbstractMessage
{

public const uint Id = 6299;
public override uint MessageId
{
    get { return Id; }
}

public short[] availables;
        public short[] unavailables;
        

public DungeonKeyRingMessage()
{
}

public DungeonKeyRingMessage(short[] availables, short[] unavailables)
        {
            this.availables = availables;
            this.unavailables = unavailables;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteUShort((ushort)availables.Length);
            foreach (var entry in availables)
            {
                 writer.WriteShort(entry);
            }
            writer.WriteUShort((ushort)unavailables.Length);
            foreach (var entry in unavailables)
            {
                 writer.WriteShort(entry);
            }
            

}

public override void Deserialize(IDataReader reader)
{

var limit = reader.ReadUShort();
            availables = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 availables[i] = reader.ReadShort();
            }
            limit = reader.ReadUShort();
            unavailables = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 unavailables[i] = reader.ReadShort();
            }
            

}


}


}