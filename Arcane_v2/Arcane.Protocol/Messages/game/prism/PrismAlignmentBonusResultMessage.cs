


















// Generated on 05/16/2016 23:27:35
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class PrismAlignmentBonusResultMessage : AbstractMessage
{

public const uint Id = 5842;
public override uint MessageId
{
    get { return Id; }
}

public Types.AlignmentBonusInformations alignmentBonus;
        

public PrismAlignmentBonusResultMessage()
{
}

public PrismAlignmentBonusResultMessage(Types.AlignmentBonusInformations alignmentBonus)
        {
            this.alignmentBonus = alignmentBonus;
        }
        

public override void Serialize(IDataWriter writer)
{

alignmentBonus.Serialize(writer);
            

}

public override void Deserialize(IDataReader reader)
{

alignmentBonus = new Types.AlignmentBonusInformations();
            alignmentBonus.Deserialize(reader);
            

}


}


}