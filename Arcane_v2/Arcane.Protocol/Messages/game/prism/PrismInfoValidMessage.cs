


















// Generated on 05/16/2016 23:27:36
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class PrismInfoValidMessage : AbstractMessage
{

public const uint Id = 5858;
public override uint MessageId
{
    get { return Id; }
}

public Types.ProtectedEntityWaitingForHelpInfo waitingForHelpInfo;
        

public PrismInfoValidMessage()
{
}

public PrismInfoValidMessage(Types.ProtectedEntityWaitingForHelpInfo waitingForHelpInfo)
        {
            this.waitingForHelpInfo = waitingForHelpInfo;
        }
        

public override void Serialize(IDataWriter writer)
{

waitingForHelpInfo.Serialize(writer);
            

}

public override void Deserialize(IDataReader reader)
{

waitingForHelpInfo = new Types.ProtectedEntityWaitingForHelpInfo();
            waitingForHelpInfo.Deserialize(reader);
            

}


}


}