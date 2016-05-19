


















// Generated on 05/16/2016 23:27:39
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class FriendInformations : AbstractContactInformations
{

public new const short Id = 78;
public override short TypeId { get { return Id; } }

public sbyte playerState;
        public int lastConnection;
        

public FriendInformations()
{
}

public FriendInformations(int accountId, string accountName, sbyte playerState, int lastConnection)
         : base(accountId, accountName)
        {
            this.playerState = playerState;
            this.lastConnection = lastConnection;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteSByte(playerState);
            writer.WriteInt(lastConnection);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            playerState = reader.ReadSByte();
            if (playerState < 0)
                throw new Exception("Forbidden value on playerState = " + playerState + ", it doesn't respect the following condition : playerState < 0");
            lastConnection = reader.ReadInt();
            if (lastConnection < 0)
                throw new Exception("Forbidden value on lastConnection = " + lastConnection + ", it doesn't respect the following condition : lastConnection < 0");
            

}


}


}