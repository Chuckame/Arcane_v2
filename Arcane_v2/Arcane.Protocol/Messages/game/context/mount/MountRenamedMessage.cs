


















// Generated on 05/16/2016 23:27:26
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class MountRenamedMessage : AbstractMessage
{

public const uint Id = 5983;
public override uint MessageId
{
    get { return Id; }
}

public double mountId;
        public string name;
        

public MountRenamedMessage()
{
}

public MountRenamedMessage(double mountId, string name)
        {
            this.mountId = mountId;
            this.name = name;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteDouble(mountId);
            writer.WriteUTF(name);
            

}

public override void Deserialize(IDataReader reader)
{

mountId = reader.ReadDouble();
            name = reader.ReadUTF();
            

}


}


}