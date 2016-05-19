


















// Generated on 05/16/2016 23:27:37
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class FightExternalInformations : AbstractType
{

public const short Id = 117;
public override short TypeId { get { return Id; } }

public int fightId;
        public int fightStart;
        public bool fightSpectatorLocked;
        public Types.FightTeamLightInformations[] fightTeams;
        public Types.FightOptionsInformations[] fightTeamsOptions;
        

public FightExternalInformations()
{
}

public FightExternalInformations(int fightId, int fightStart, bool fightSpectatorLocked, Types.FightTeamLightInformations[] fightTeams, Types.FightOptionsInformations[] fightTeamsOptions)
        {
            this.fightId = fightId;
            this.fightStart = fightStart;
            this.fightSpectatorLocked = fightSpectatorLocked;
            this.fightTeams = fightTeams;
            this.fightTeamsOptions = fightTeamsOptions;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(fightId);
            writer.WriteInt(fightStart);
            writer.WriteBoolean(fightSpectatorLocked);
            writer.WriteUShort((ushort)fightTeams.Length);
            foreach (var entry in fightTeams)
            {
                 entry.Serialize(writer);
            }
            writer.WriteUShort((ushort)fightTeamsOptions.Length);
            foreach (var entry in fightTeamsOptions)
            {
                 entry.Serialize(writer);
            }
            

}

public override void Deserialize(IDataReader reader)
{

fightId = reader.ReadInt();
            fightStart = reader.ReadInt();
            if (fightStart < 0)
                throw new Exception("Forbidden value on fightStart = " + fightStart + ", it doesn't respect the following condition : fightStart < 0");
            fightSpectatorLocked = reader.ReadBoolean();
            var limit = reader.ReadUShort();
            fightTeams = new Types.FightTeamLightInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 fightTeams[i] = new Types.FightTeamLightInformations();
                 fightTeams[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            fightTeamsOptions = new Types.FightOptionsInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 fightTeamsOptions[i] = new Types.FightOptionsInformations();
                 fightTeamsOptions[i].Deserialize(reader);
            }
            

}


}


}