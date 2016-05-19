


















// Generated on 05/16/2016 23:27:36
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class CheckFileRequestMessage : AbstractMessage
{

public const uint Id = 6154;
public override uint MessageId
{
    get { return Id; }
}

public string filename;
        public sbyte type;
        

public CheckFileRequestMessage()
{
}

public CheckFileRequestMessage(string filename, sbyte type)
        {
            this.filename = filename;
            this.type = type;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteUTF(filename);
            writer.WriteSByte(type);
            

}

public override void Deserialize(IDataReader reader)
{

filename = reader.ReadUTF();
            type = reader.ReadSByte();
            if (type < 0)
                throw new Exception("Forbidden value on type = " + type + ", it doesn't respect the following condition : type < 0");
            

}


}


}