


















// Generated on 05/16/2016 23:27:22
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class AbstractGameActionFightTargetedAbilityMessage : AbstractGameActionMessage
{

public new const uint Id = 6118;
public override uint MessageId
{
    get { return Id; }
}

public short destinationCellId;
        public sbyte critical;
        public bool silentCast;
        

public AbstractGameActionFightTargetedAbilityMessage()
{
}

public AbstractGameActionFightTargetedAbilityMessage(short actionId, int sourceId, short destinationCellId, sbyte critical, bool silentCast)
         : base(actionId, sourceId)
        {
            this.destinationCellId = destinationCellId;
            this.critical = critical;
            this.silentCast = silentCast;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteShort(destinationCellId);
            writer.WriteSByte(critical);
            writer.WriteBoolean(silentCast);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            destinationCellId = reader.ReadShort();
            if (destinationCellId < -1 || destinationCellId > 559)
                throw new Exception("Forbidden value on destinationCellId = " + destinationCellId + ", it doesn't respect the following condition : destinationCellId < -1 || destinationCellId > 559");
            critical = reader.ReadSByte();
            if (critical < 0)
                throw new Exception("Forbidden value on critical = " + critical + ", it doesn't respect the following condition : critical < 0");
            silentCast = reader.ReadBoolean();
            

}


}


}