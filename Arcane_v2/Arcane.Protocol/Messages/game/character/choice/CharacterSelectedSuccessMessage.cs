


















// Generated on 05/16/2016 23:27:24
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class CharacterSelectedSuccessMessage : AbstractMessage
{

public const uint Id = 153;
public override uint MessageId
{
    get { return Id; }
}

public Types.CharacterBaseInformations infos;
        

public CharacterSelectedSuccessMessage()
{
}

public CharacterSelectedSuccessMessage(Types.CharacterBaseInformations infos)
        {
            this.infos = infos;
        }
        

public override void Serialize(IDataWriter writer)
{

infos.Serialize(writer);
            

}

public override void Deserialize(IDataReader reader)
{

infos = new Types.CharacterBaseInformations();
            infos.Deserialize(reader);
            

}


}


}