


















// Generated on 05/16/2016 23:27:34
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class ExchangeStartOkCraftWithInformationMessage : ExchangeStartOkCraftMessage
{

public new const uint Id = 5941;
public override uint MessageId
{
    get { return Id; }
}

public sbyte nbCase;
        public int skillId;
        

public ExchangeStartOkCraftWithInformationMessage()
{
}

public ExchangeStartOkCraftWithInformationMessage(sbyte nbCase, int skillId)
        {
            this.nbCase = nbCase;
            this.skillId = skillId;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteSByte(nbCase);
            writer.WriteInt(skillId);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            nbCase = reader.ReadSByte();
            if (nbCase < 0)
                throw new Exception("Forbidden value on nbCase = " + nbCase + ", it doesn't respect the following condition : nbCase < 0");
            skillId = reader.ReadInt();
            if (skillId < 0)
                throw new Exception("Forbidden value on skillId = " + skillId + ", it doesn't respect the following condition : skillId < 0");
            

}


}


}