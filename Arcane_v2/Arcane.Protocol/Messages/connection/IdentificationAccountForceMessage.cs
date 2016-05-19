


















// Generated on 05/16/2016 23:27:21
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class IdentificationAccountForceMessage : IdentificationMessage
{

public new const uint Id = 6119;
public override uint MessageId
{
    get { return Id; }
}

public string forcedAccountLogin;
        

public IdentificationAccountForceMessage()
{
}

public IdentificationAccountForceMessage(bool autoconnect, bool useCertificate, bool useLoginToken, Types.Version version, string lang, string login, sbyte[] credentials, short serverId, string forcedAccountLogin)
         : base(autoconnect, useCertificate, useLoginToken, version, lang, login, credentials, serverId)
        {
            this.forcedAccountLogin = forcedAccountLogin;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteUTF(forcedAccountLogin);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            forcedAccountLogin = reader.ReadUTF();
            

}


}


}