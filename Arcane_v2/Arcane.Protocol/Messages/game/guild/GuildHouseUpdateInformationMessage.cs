


















// Generated on 05/16/2016 23:27:31
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class GuildHouseUpdateInformationMessage : AbstractMessage
{

public const uint Id = 6181;
public override uint MessageId
{
    get { return Id; }
}

public Types.HouseInformationsForGuild housesInformations;
        

public GuildHouseUpdateInformationMessage()
{
}

public GuildHouseUpdateInformationMessage(Types.HouseInformationsForGuild housesInformations)
        {
            this.housesInformations = housesInformations;
        }
        

public override void Serialize(IDataWriter writer)
{

housesInformations.Serialize(writer);
            

}

public override void Deserialize(IDataReader reader)
{

housesInformations = new Types.HouseInformationsForGuild();
            housesInformations.Deserialize(reader);
            

}


}


}