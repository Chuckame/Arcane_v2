


















// Generated on 05/16/2016 23:27:22
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class SelectedServerRefusedMessage : AbstractMessage
{

public const uint Id = 41;
public override uint MessageId
{
    get { return Id; }
}

public short serverId;
        public sbyte error;
        public sbyte serverStatus;
        

public SelectedServerRefusedMessage()
{
}

public SelectedServerRefusedMessage(short serverId, sbyte error, sbyte serverStatus)
        {
            this.serverId = serverId;
            this.error = error;
            this.serverStatus = serverStatus;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteShort(serverId);
            writer.WriteSByte(error);
            writer.WriteSByte(serverStatus);
            

}

public override void Deserialize(IDataReader reader)
{

serverId = reader.ReadShort();
            error = reader.ReadSByte();
            if (error < 0)
                throw new Exception("Forbidden value on error = " + error + ", it doesn't respect the following condition : error < 0");
            serverStatus = reader.ReadSByte();
            if (serverStatus < 0)
                throw new Exception("Forbidden value on serverStatus = " + serverStatus + ", it doesn't respect the following condition : serverStatus < 0");
            

}


}


}