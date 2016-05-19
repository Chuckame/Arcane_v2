


















// Generated on 05/16/2016 23:27:39
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class ObjectEffect : AbstractType
{

public const short Id = 76;
public override short TypeId { get { return Id; } }

public short actionId;
        

public ObjectEffect()
{
}

public ObjectEffect(short actionId)
        {
            this.actionId = actionId;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteShort(actionId);
            

}

public override void Deserialize(IDataReader reader)
{

actionId = reader.ReadShort();
            if (actionId < 0)
                throw new Exception("Forbidden value on actionId = " + actionId + ", it doesn't respect the following condition : actionId < 0");
            

}


}


}