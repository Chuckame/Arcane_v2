


















// Generated on 05/16/2016 23:27:39
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class MountInformationsForPaddock : AbstractType
{

public const short Id = 184;
public override short TypeId { get { return Id; } }

public int modelId;
        public string name;
        public string ownerName;
        

public MountInformationsForPaddock()
{
}

public MountInformationsForPaddock(int modelId, string name, string ownerName)
        {
            this.modelId = modelId;
            this.name = name;
            this.ownerName = ownerName;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(modelId);
            writer.WriteUTF(name);
            writer.WriteUTF(ownerName);
            

}

public override void Deserialize(IDataReader reader)
{

modelId = reader.ReadInt();
            name = reader.ReadUTF();
            ownerName = reader.ReadUTF();
            

}


}


}