


















// Generated on 05/16/2016 23:27:27
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class GameRolePlayPlayerLifeStatusMessage : AbstractMessage
{

public const uint Id = 5996;
public override uint MessageId
{
    get { return Id; }
}

public sbyte state;
        

public GameRolePlayPlayerLifeStatusMessage()
{
}

public GameRolePlayPlayerLifeStatusMessage(sbyte state)
        {
            this.state = state;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteSByte(state);
            

}

public override void Deserialize(IDataReader reader)
{

state = reader.ReadSByte();
            if (state < 0)
                throw new Exception("Forbidden value on state = " + state + ", it doesn't respect the following condition : state < 0");
            

}


}


}