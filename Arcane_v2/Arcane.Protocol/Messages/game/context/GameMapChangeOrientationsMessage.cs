


















// Generated on 05/16/2016 23:27:25
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class GameMapChangeOrientationsMessage : AbstractMessage
{

public const uint Id = 6155;
public override uint MessageId
{
    get { return Id; }
}

public Types.ActorOrientation[] orientations;
        

public GameMapChangeOrientationsMessage()
{
}

public GameMapChangeOrientationsMessage(Types.ActorOrientation[] orientations)
        {
            this.orientations = orientations;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteUShort((ushort)orientations.Length);
            foreach (var entry in orientations)
            {
                 entry.Serialize(writer);
            }
            

}

public override void Deserialize(IDataReader reader)
{

var limit = reader.ReadUShort();
            orientations = new Types.ActorOrientation[limit];
            for (int i = 0; i < limit; i++)
            {
                 orientations[i] = new Types.ActorOrientation();
                 orientations[i].Deserialize(reader);
            }
            

}


}


}