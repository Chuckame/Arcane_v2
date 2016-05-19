


















// Generated on 05/16/2016 23:27:39
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class ObjectEffectString : ObjectEffect
{

public new const short Id = 74;
public override short TypeId { get { return Id; } }

public string value;
        

public ObjectEffectString()
{
}

public ObjectEffectString(short actionId, string value)
         : base(actionId)
        {
            this.value = value;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteUTF(value);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            value = reader.ReadUTF();
            

}


}


}