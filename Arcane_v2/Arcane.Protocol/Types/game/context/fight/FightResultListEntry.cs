


















// Generated on 05/16/2016 23:27:37
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class FightResultListEntry : AbstractType
{

public const short Id = 16;
public override short TypeId { get { return Id; } }

public short outcome;
        public Types.FightLoot rewards;
        

public FightResultListEntry()
{
}

public FightResultListEntry(short outcome, Types.FightLoot rewards)
        {
            this.outcome = outcome;
            this.rewards = rewards;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteShort(outcome);
            rewards.Serialize(writer);
            

}

public override void Deserialize(IDataReader reader)
{

outcome = reader.ReadShort();
            if (outcome < 0)
                throw new Exception("Forbidden value on outcome = " + outcome + ", it doesn't respect the following condition : outcome < 0");
            rewards = new Types.FightLoot();
            rewards.Deserialize(reader);
            

}


}


}