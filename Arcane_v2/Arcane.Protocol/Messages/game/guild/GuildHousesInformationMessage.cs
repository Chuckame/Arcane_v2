


















// Generated on 05/16/2016 23:27:31
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class GuildHousesInformationMessage : AbstractMessage
{

public const uint Id = 5919;
public override uint MessageId
{
    get { return Id; }
}

public Types.HouseInformationsForGuild[] housesInformations;
        

public GuildHousesInformationMessage()
{
}

public GuildHousesInformationMessage(Types.HouseInformationsForGuild[] housesInformations)
        {
            this.housesInformations = housesInformations;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteUShort((ushort)housesInformations.Length);
            foreach (var entry in housesInformations)
            {
                 entry.Serialize(writer);
            }
            

}

public override void Deserialize(IDataReader reader)
{

var limit = reader.ReadUShort();
            housesInformations = new Types.HouseInformationsForGuild[limit];
            for (int i = 0; i < limit; i++)
            {
                 housesInformations[i] = new Types.HouseInformationsForGuild();
                 housesInformations[i].Deserialize(reader);
            }
            

}


}


}