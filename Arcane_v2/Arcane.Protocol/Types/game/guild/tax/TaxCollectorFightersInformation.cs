


















// Generated on 05/16/2016 23:27:39
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class TaxCollectorFightersInformation : AbstractType
{

public const short Id = 169;
public override short TypeId { get { return Id; } }

public int collectorId;
        public Types.CharacterMinimalPlusLookInformations[] allyCharactersInformations;
        public Types.CharacterMinimalPlusLookInformations[] enemyCharactersInformations;
        

public TaxCollectorFightersInformation()
{
}

public TaxCollectorFightersInformation(int collectorId, Types.CharacterMinimalPlusLookInformations[] allyCharactersInformations, Types.CharacterMinimalPlusLookInformations[] enemyCharactersInformations)
        {
            this.collectorId = collectorId;
            this.allyCharactersInformations = allyCharactersInformations;
            this.enemyCharactersInformations = enemyCharactersInformations;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(collectorId);
            writer.WriteUShort((ushort)allyCharactersInformations.Length);
            foreach (var entry in allyCharactersInformations)
            {
                 entry.Serialize(writer);
            }
            writer.WriteUShort((ushort)enemyCharactersInformations.Length);
            foreach (var entry in enemyCharactersInformations)
            {
                 entry.Serialize(writer);
            }
            

}

public override void Deserialize(IDataReader reader)
{

collectorId = reader.ReadInt();
            var limit = reader.ReadUShort();
            allyCharactersInformations = new Types.CharacterMinimalPlusLookInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 allyCharactersInformations[i] = new Types.CharacterMinimalPlusLookInformations();
                 allyCharactersInformations[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            enemyCharactersInformations = new Types.CharacterMinimalPlusLookInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 enemyCharactersInformations[i] = new Types.CharacterMinimalPlusLookInformations();
                 enemyCharactersInformations[i].Deserialize(reader);
            }
            

}


}


}