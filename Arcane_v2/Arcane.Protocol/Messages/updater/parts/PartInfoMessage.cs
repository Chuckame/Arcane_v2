


















// Generated on 05/16/2016 23:27:37
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class PartInfoMessage : AbstractMessage
{

public const uint Id = 1508;
public override uint MessageId
{
    get { return Id; }
}

public Types.ContentPart part;
        public float installationPercent;
        

public PartInfoMessage()
{
}

public PartInfoMessage(Types.ContentPart part, float installationPercent)
        {
            this.part = part;
            this.installationPercent = installationPercent;
        }
        

public override void Serialize(IDataWriter writer)
{

part.Serialize(writer);
            writer.WriteFloat(installationPercent);
            

}

public override void Deserialize(IDataReader reader)
{

part = new Types.ContentPart();
            part.Deserialize(reader);
            installationPercent = reader.ReadFloat();
            

}


}


}