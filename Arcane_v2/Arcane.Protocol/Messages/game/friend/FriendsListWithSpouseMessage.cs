


















// Generated on 05/16/2016 23:27:31
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class FriendsListWithSpouseMessage : FriendsListMessage
{

public new const uint Id = 5931;
public override uint MessageId
{
    get { return Id; }
}

public Types.FriendSpouseInformations spouse;
        

public FriendsListWithSpouseMessage()
{
}

public FriendsListWithSpouseMessage(Types.FriendInformations[] friendsList, Types.FriendSpouseInformations spouse)
         : base(friendsList)
        {
            this.spouse = spouse;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteShort(spouse.TypeId);
            spouse.Serialize(writer);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            spouse = Types.ProtocolTypeManager.GetInstance<Types.FriendSpouseInformations>(reader.ReadShort());
            spouse.Deserialize(reader);
            

}


}


}