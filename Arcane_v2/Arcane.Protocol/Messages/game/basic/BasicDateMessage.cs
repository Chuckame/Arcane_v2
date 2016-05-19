


















// Generated on 05/16/2016 23:27:24
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class BasicDateMessage : AbstractMessage
{

public const uint Id = 177;
public override uint MessageId
{
    get { return Id; }
}

public sbyte day;
        public sbyte month;
        public short year;
        

public BasicDateMessage()
{
}

public BasicDateMessage(sbyte day, sbyte month, short year)
        {
            this.day = day;
            this.month = month;
            this.year = year;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteSByte(day);
            writer.WriteSByte(month);
            writer.WriteShort(year);
            

}

public override void Deserialize(IDataReader reader)
{

day = reader.ReadSByte();
            if (day < 0)
                throw new Exception("Forbidden value on day = " + day + ", it doesn't respect the following condition : day < 0");
            month = reader.ReadSByte();
            if (month < 0)
                throw new Exception("Forbidden value on month = " + month + ", it doesn't respect the following condition : month < 0");
            year = reader.ReadShort();
            if (year < 0)
                throw new Exception("Forbidden value on year = " + year + ", it doesn't respect the following condition : year < 0");
            

}


}


}