


















// Generated on 05/16/2016 23:27:36
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class CharacterReportMessage : AbstractMessage
{

public const uint Id = 6079;
public override uint MessageId
{
    get { return Id; }
}

public uint reportedId;
        public sbyte reason;
        

public CharacterReportMessage()
{
}

public CharacterReportMessage(uint reportedId, sbyte reason)
        {
            this.reportedId = reportedId;
            this.reason = reason;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteUInt(reportedId);
            writer.WriteSByte(reason);
            

}

public override void Deserialize(IDataReader reader)
{

reportedId = reader.ReadUInt();
            if (reportedId < 0 || reportedId > 4.294967295E9)
                throw new Exception("Forbidden value on reportedId = " + reportedId + ", it doesn't respect the following condition : reportedId < 0 || reportedId > 4.294967295E9");
            reason = reader.ReadSByte();
            if (reason < 0)
                throw new Exception("Forbidden value on reason = " + reason + ", it doesn't respect the following condition : reason < 0");
            

}


}


}