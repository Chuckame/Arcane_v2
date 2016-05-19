


















// Generated on 05/16/2016 23:27:22
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class NicknameChoiceRequestMessage : AbstractMessage
{

public const uint Id = 5639;
public override uint MessageId
{
    get { return Id; }
}

public string nickname;
        

public NicknameChoiceRequestMessage()
{
}

public NicknameChoiceRequestMessage(string nickname)
        {
            this.nickname = nickname;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteUTF(nickname);
            

}

public override void Deserialize(IDataReader reader)
{

nickname = reader.ReadUTF();
            

}


}


}