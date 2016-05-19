


















// Generated on 05/16/2016 23:27:31
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class LeaveDialogRequestMessage : AbstractMessage
{

public const uint Id = 5501;
public override uint MessageId
{
    get { return Id; }
}

public sbyte dialogType;
        

public LeaveDialogRequestMessage()
{
}

public LeaveDialogRequestMessage(sbyte dialogType)
        {
            this.dialogType = dialogType;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteSByte(dialogType);
            

}

public override void Deserialize(IDataReader reader)
{

dialogType = reader.ReadSByte();
            if (dialogType < 0)
                throw new Exception("Forbidden value on dialogType = " + dialogType + ", it doesn't respect the following condition : dialogType < 0");
            

}


}


}