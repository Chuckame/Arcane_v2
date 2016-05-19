


















// Generated on 05/16/2016 23:27:21
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class IdentificationSuccessWithLoginTokenMessage : IdentificationSuccessMessage
{

public new const uint Id = 6209;
public override uint MessageId
{
    get { return Id; }
}

public string loginToken;
        

public IdentificationSuccessWithLoginTokenMessage()
{
}

public IdentificationSuccessWithLoginTokenMessage(bool hasRights, bool wasAlreadyConnected, string login, string nickname, int accountId, sbyte communityId, string secretQuestion, double subscriptionEndDate, double accountCreation, string loginToken)
         : base(hasRights, wasAlreadyConnected, login, nickname, accountId, communityId, secretQuestion, subscriptionEndDate, accountCreation)
        {
            this.loginToken = loginToken;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteUTF(loginToken);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            loginToken = reader.ReadUTF();
            

}


}


}