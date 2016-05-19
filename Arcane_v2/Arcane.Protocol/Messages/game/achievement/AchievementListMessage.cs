


















// Generated on 05/16/2016 23:27:22
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class AchievementListMessage : AbstractMessage
{

public const uint Id = 6205;
public override uint MessageId
{
    get { return Id; }
}

public Types.Achievement[] startedAchievements;
        public short[] finishedAchievementsIds;
        

public AchievementListMessage()
{
}

public AchievementListMessage(Types.Achievement[] startedAchievements, short[] finishedAchievementsIds)
        {
            this.startedAchievements = startedAchievements;
            this.finishedAchievementsIds = finishedAchievementsIds;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteUShort((ushort)startedAchievements.Length);
            foreach (var entry in startedAchievements)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
            }
            writer.WriteUShort((ushort)finishedAchievementsIds.Length);
            foreach (var entry in finishedAchievementsIds)
            {
                 writer.WriteShort(entry);
            }
            

}

public override void Deserialize(IDataReader reader)
{

var limit = reader.ReadUShort();
            startedAchievements = new Types.Achievement[limit];
            for (int i = 0; i < limit; i++)
            {
                 startedAchievements[i] = Types.ProtocolTypeManager.GetInstance<Types.Achievement>(reader.ReadShort());
                 startedAchievements[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            finishedAchievementsIds = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 finishedAchievementsIds[i] = reader.ReadShort();
            }
            

}


}


}