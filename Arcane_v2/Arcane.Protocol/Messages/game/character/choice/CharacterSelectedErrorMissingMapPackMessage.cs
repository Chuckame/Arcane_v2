


















// Generated on 05/16/2016 23:27:24
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class CharacterSelectedErrorMissingMapPackMessage : CharacterSelectedErrorMessage
{

public new const uint Id = 6300;
public override uint MessageId
{
    get { return Id; }
}

public int subAreaId;
        

public CharacterSelectedErrorMissingMapPackMessage()
{
}

public CharacterSelectedErrorMissingMapPackMessage(int subAreaId)
        {
            this.subAreaId = subAreaId;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteInt(subAreaId);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            subAreaId = reader.ReadInt();
            if (subAreaId < 0)
                throw new Exception("Forbidden value on subAreaId = " + subAreaId + ", it doesn't respect the following condition : subAreaId < 0");
            

}


}


}