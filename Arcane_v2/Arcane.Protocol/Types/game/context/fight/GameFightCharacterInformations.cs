


















// Generated on 05/16/2016 23:27:38
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class GameFightCharacterInformations : GameFightFighterNamedInformations
{

public new const short Id = 46;
public override short TypeId { get { return Id; } }

public short level;
        public Types.ActorAlignmentInformations alignmentInfos;
        public sbyte breed;
        

public GameFightCharacterInformations()
{
}

public GameFightCharacterInformations(int contextualId, Types.EntityLook look, Types.EntityDispositionInformations disposition, sbyte teamId, bool alive, Types.GameFightMinimalStats stats, string name, short level, Types.ActorAlignmentInformations alignmentInfos, sbyte breed)
         : base(contextualId, look, disposition, teamId, alive, stats, name)
        {
            this.level = level;
            this.alignmentInfos = alignmentInfos;
            this.breed = breed;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteShort(level);
            alignmentInfos.Serialize(writer);
            writer.WriteSByte(breed);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            level = reader.ReadShort();
            if (level < 0)
                throw new Exception("Forbidden value on level = " + level + ", it doesn't respect the following condition : level < 0");
            alignmentInfos = new Types.ActorAlignmentInformations();
            alignmentInfos.Deserialize(reader);
            breed = reader.ReadSByte();
            

}


}


}