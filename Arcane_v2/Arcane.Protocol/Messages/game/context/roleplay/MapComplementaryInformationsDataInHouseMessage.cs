


















// Generated on 05/16/2016 23:27:27
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class MapComplementaryInformationsDataInHouseMessage : MapComplementaryInformationsDataMessage
{

public new const uint Id = 6130;
public override uint MessageId
{
    get { return Id; }
}

public Types.HouseInformationsInside currentHouse;
        

public MapComplementaryInformationsDataInHouseMessage()
{
}

public MapComplementaryInformationsDataInHouseMessage(short subAreaId, int mapId, sbyte subareaAlignmentSide, Types.HouseInformations[] houses, Types.GameRolePlayActorInformations[] actors, Types.InteractiveElement[] interactiveElements, Types.StatedElement[] statedElements, Types.MapObstacle[] obstacles, Types.FightCommonInformations[] fights, Types.HouseInformationsInside currentHouse)
         : base(subAreaId, mapId, subareaAlignmentSide, houses, actors, interactiveElements, statedElements, obstacles, fights)
        {
            this.currentHouse = currentHouse;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            currentHouse.Serialize(writer);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            currentHouse = new Types.HouseInformationsInside();
            currentHouse.Deserialize(reader);
            

}


}


}