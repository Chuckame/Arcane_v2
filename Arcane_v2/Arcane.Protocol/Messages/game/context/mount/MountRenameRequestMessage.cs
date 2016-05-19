


















// Generated on 05/16/2016 23:27:26
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class MountRenameRequestMessage : AbstractMessage
{

public const uint Id = 5987;
public override uint MessageId
{
    get { return Id; }
}

public string name;
        public double mountId;
        

public MountRenameRequestMessage()
{
}

public MountRenameRequestMessage(string name, double mountId)
        {
            this.name = name;
            this.mountId = mountId;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteUTF(name);
            writer.WriteDouble(mountId);
            

}

public override void Deserialize(IDataReader reader)
{

name = reader.ReadUTF();
            mountId = reader.ReadDouble();
            

}


}


}