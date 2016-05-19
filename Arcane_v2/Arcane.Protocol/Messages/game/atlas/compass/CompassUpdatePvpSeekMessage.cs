


















// Generated on 05/16/2016 23:27:24
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class CompassUpdatePvpSeekMessage : CompassUpdateMessage
{

public new const uint Id = 6013;
public override uint MessageId
{
    get { return Id; }
}

public int memberId;
        public string memberName;
        

public CompassUpdatePvpSeekMessage()
{
}

public CompassUpdatePvpSeekMessage(sbyte type, short worldX, short worldY, int memberId, string memberName)
         : base(type, worldX, worldY)
        {
            this.memberId = memberId;
            this.memberName = memberName;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteInt(memberId);
            writer.WriteUTF(memberName);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            memberId = reader.ReadInt();
            if (memberId < 0)
                throw new Exception("Forbidden value on memberId = " + memberId + ", it doesn't respect the following condition : memberId < 0");
            memberName = reader.ReadUTF();
            

}


}


}