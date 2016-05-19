


















// Generated on 05/16/2016 23:27:36
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class PrismFightAttackerAddMessage : AbstractMessage
{

public const uint Id = 5893;
public override uint MessageId
{
    get { return Id; }
}

public double fightId;
        public Types.CharacterMinimalPlusLookAndGradeInformations[] charactersDescription;
        

public PrismFightAttackerAddMessage()
{
}

public PrismFightAttackerAddMessage(double fightId, Types.CharacterMinimalPlusLookAndGradeInformations[] charactersDescription)
        {
            this.fightId = fightId;
            this.charactersDescription = charactersDescription;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteDouble(fightId);
            writer.WriteUShort((ushort)charactersDescription.Length);
            foreach (var entry in charactersDescription)
            {
                 entry.Serialize(writer);
            }
            

}

public override void Deserialize(IDataReader reader)
{

fightId = reader.ReadDouble();
            var limit = reader.ReadUShort();
            charactersDescription = new Types.CharacterMinimalPlusLookAndGradeInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 charactersDescription[i] = new Types.CharacterMinimalPlusLookAndGradeInformations();
                 charactersDescription[i].Deserialize(reader);
            }
            

}


}


}