


















// Generated on 05/16/2016 23:27:37
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class GameContextActorInformations : AbstractType
{

public const short Id = 150;
public override short TypeId { get { return Id; } }

public int contextualId;
        public Types.EntityLook look;
        public Types.EntityDispositionInformations disposition;
        

public GameContextActorInformations()
{
}

public GameContextActorInformations(int contextualId, Types.EntityLook look, Types.EntityDispositionInformations disposition)
        {
            this.contextualId = contextualId;
            this.look = look;
            this.disposition = disposition;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(contextualId);
            look.Serialize(writer);
            writer.WriteShort(disposition.TypeId);
            disposition.Serialize(writer);
            

}

public override void Deserialize(IDataReader reader)
{

contextualId = reader.ReadInt();
            look = new Types.EntityLook();
            look.Deserialize(reader);
            disposition = Types.ProtocolTypeManager.GetInstance<Types.EntityDispositionInformations>(reader.ReadShort());
            disposition.Deserialize(reader);
            

}


}


}