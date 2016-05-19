


















// Generated on 05/16/2016 23:27:22
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class AchievementUpdateMessage : AbstractMessage
{

public const uint Id = 6207;
public override uint MessageId
{
    get { return Id; }
}

public Types.Achievement achievement;
        

public AchievementUpdateMessage()
{
}

public AchievementUpdateMessage(Types.Achievement achievement)
        {
            this.achievement = achievement;
        }
        

public override void Serialize(IDataWriter writer)
{

achievement.Serialize(writer);
            

}

public override void Deserialize(IDataReader reader)
{

achievement = new Types.Achievement();
            achievement.Deserialize(reader);
            

}


}


}