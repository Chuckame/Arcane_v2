


















// Generated on 05/16/2016 23:27:32
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class InteractiveUseEndedMessage : AbstractMessage
{

public const uint Id = 6112;
public override uint MessageId
{
    get { return Id; }
}

public int elemId;
        public short skillId;
        

public InteractiveUseEndedMessage()
{
}

public InteractiveUseEndedMessage(int elemId, short skillId)
        {
            this.elemId = elemId;
            this.skillId = skillId;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(elemId);
            writer.WriteShort(skillId);
            

}

public override void Deserialize(IDataReader reader)
{

elemId = reader.ReadInt();
            if (elemId < 0)
                throw new Exception("Forbidden value on elemId = " + elemId + ", it doesn't respect the following condition : elemId < 0");
            skillId = reader.ReadShort();
            if (skillId < 0)
                throw new Exception("Forbidden value on skillId = " + skillId + ", it doesn't respect the following condition : skillId < 0");
            

}


}


}