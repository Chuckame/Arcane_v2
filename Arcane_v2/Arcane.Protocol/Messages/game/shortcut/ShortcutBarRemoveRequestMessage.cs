


















// Generated on 05/16/2016 23:27:36
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class ShortcutBarRemoveRequestMessage : AbstractMessage
{

public const uint Id = 6228;
public override uint MessageId
{
    get { return Id; }
}

public sbyte barType;
        public int slot;
        

public ShortcutBarRemoveRequestMessage()
{
}

public ShortcutBarRemoveRequestMessage(sbyte barType, int slot)
        {
            this.barType = barType;
            this.slot = slot;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteSByte(barType);
            writer.WriteInt(slot);
            

}

public override void Deserialize(IDataReader reader)
{

barType = reader.ReadSByte();
            if (barType < 0)
                throw new Exception("Forbidden value on barType = " + barType + ", it doesn't respect the following condition : barType < 0");
            slot = reader.ReadInt();
            if (slot < 0 || slot > 99)
                throw new Exception("Forbidden value on slot = " + slot + ", it doesn't respect the following condition : slot < 0 || slot > 99");
            

}


}


}