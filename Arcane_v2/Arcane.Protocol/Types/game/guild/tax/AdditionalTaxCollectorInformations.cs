


















// Generated on 05/16/2016 23:27:39
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class AdditionalTaxCollectorInformations : AbstractType
{

public const short Id = 165;
public override short TypeId { get { return Id; } }

public string collectorCallerName;
        public int date;
        

public AdditionalTaxCollectorInformations()
{
}

public AdditionalTaxCollectorInformations(string collectorCallerName, int date)
        {
            this.collectorCallerName = collectorCallerName;
            this.date = date;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteUTF(collectorCallerName);
            writer.WriteInt(date);
            

}

public override void Deserialize(IDataReader reader)
{

collectorCallerName = reader.ReadUTF();
            date = reader.ReadInt();
            if (date < 0)
                throw new Exception("Forbidden value on date = " + date + ", it doesn't respect the following condition : date < 0");
            

}


}


}