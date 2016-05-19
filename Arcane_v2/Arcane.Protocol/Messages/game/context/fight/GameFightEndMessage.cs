


















// Generated on 05/16/2016 23:27:26
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class GameFightEndMessage : AbstractMessage
{

public const uint Id = 720;
public override uint MessageId
{
    get { return Id; }
}

public int duration;
        public short ageBonus;
        public Types.FightResultListEntry[] results;
        

public GameFightEndMessage()
{
}

public GameFightEndMessage(int duration, short ageBonus, Types.FightResultListEntry[] results)
        {
            this.duration = duration;
            this.ageBonus = ageBonus;
            this.results = results;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(duration);
            writer.WriteShort(ageBonus);
            writer.WriteUShort((ushort)results.Length);
            foreach (var entry in results)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
            }
            

}

public override void Deserialize(IDataReader reader)
{

duration = reader.ReadInt();
            if (duration < 0)
                throw new Exception("Forbidden value on duration = " + duration + ", it doesn't respect the following condition : duration < 0");
            ageBonus = reader.ReadShort();
            var limit = reader.ReadUShort();
            results = new Types.FightResultListEntry[limit];
            for (int i = 0; i < limit; i++)
            {
                 results[i] = Types.ProtocolTypeManager.GetInstance<Types.FightResultListEntry>(reader.ReadShort());
                 results[i].Deserialize(reader);
            }
            

}


}


}