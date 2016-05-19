


















// Generated on 05/16/2016 23:27:39
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class GuildEmblem : AbstractType
{

public const short Id = 87;
public override short TypeId { get { return Id; } }

public short symbolShape;
        public int symbolColor;
        public short backgroundShape;
        public int backgroundColor;
        

public GuildEmblem()
{
}

public GuildEmblem(short symbolShape, int symbolColor, short backgroundShape, int backgroundColor)
        {
            this.symbolShape = symbolShape;
            this.symbolColor = symbolColor;
            this.backgroundShape = backgroundShape;
            this.backgroundColor = backgroundColor;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteShort(symbolShape);
            writer.WriteInt(symbolColor);
            writer.WriteShort(backgroundShape);
            writer.WriteInt(backgroundColor);
            

}

public override void Deserialize(IDataReader reader)
{

symbolShape = reader.ReadShort();
            symbolColor = reader.ReadInt();
            backgroundShape = reader.ReadShort();
            backgroundColor = reader.ReadInt();
            

}


}


}