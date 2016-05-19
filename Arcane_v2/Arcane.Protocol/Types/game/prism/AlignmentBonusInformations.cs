


















// Generated on 05/16/2016 23:27:39
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class AlignmentBonusInformations : AbstractType
{

public const short Id = 135;
public override short TypeId { get { return Id; } }

public int pctbonus;
        public double grademult;
        

public AlignmentBonusInformations()
{
}

public AlignmentBonusInformations(int pctbonus, double grademult)
        {
            this.pctbonus = pctbonus;
            this.grademult = grademult;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(pctbonus);
            writer.WriteDouble(grademult);
            

}

public override void Deserialize(IDataReader reader)
{

pctbonus = reader.ReadInt();
            if (pctbonus < 0)
                throw new Exception("Forbidden value on pctbonus = " + pctbonus + ", it doesn't respect the following condition : pctbonus < 0");
            grademult = reader.ReadDouble();
            

}


}


}