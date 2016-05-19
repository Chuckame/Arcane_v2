


















// Generated on 05/16/2016 23:27:39
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class StatedElement : AbstractType
{

public const short Id = 108;
public override short TypeId { get { return Id; } }

public int elementId;
        public short elementCellId;
        public int elementState;
        

public StatedElement()
{
}

public StatedElement(int elementId, short elementCellId, int elementState)
        {
            this.elementId = elementId;
            this.elementCellId = elementCellId;
            this.elementState = elementState;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(elementId);
            writer.WriteShort(elementCellId);
            writer.WriteInt(elementState);
            

}

public override void Deserialize(IDataReader reader)
{

elementId = reader.ReadInt();
            if (elementId < 0)
                throw new Exception("Forbidden value on elementId = " + elementId + ", it doesn't respect the following condition : elementId < 0");
            elementCellId = reader.ReadShort();
            if (elementCellId < 0 || elementCellId > 559)
                throw new Exception("Forbidden value on elementCellId = " + elementCellId + ", it doesn't respect the following condition : elementCellId < 0 || elementCellId > 559");
            elementState = reader.ReadInt();
            if (elementState < 0)
                throw new Exception("Forbidden value on elementState = " + elementState + ", it doesn't respect the following condition : elementState < 0");
            

}


}


}