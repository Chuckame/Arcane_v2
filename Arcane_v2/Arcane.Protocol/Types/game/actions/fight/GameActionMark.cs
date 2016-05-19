


















// Generated on 05/16/2016 23:27:37
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class GameActionMark : AbstractType
{

public const short Id = 351;
public override short TypeId { get { return Id; } }

public int markAuthorId;
        public int markSpellId;
        public short markId;
        public sbyte markType;
        public Types.GameActionMarkedCell[] cells;
        

public GameActionMark()
{
}

public GameActionMark(int markAuthorId, int markSpellId, short markId, sbyte markType, Types.GameActionMarkedCell[] cells)
        {
            this.markAuthorId = markAuthorId;
            this.markSpellId = markSpellId;
            this.markId = markId;
            this.markType = markType;
            this.cells = cells;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(markAuthorId);
            writer.WriteInt(markSpellId);
            writer.WriteShort(markId);
            writer.WriteSByte(markType);
            writer.WriteUShort((ushort)cells.Length);
            foreach (var entry in cells)
            {
                 entry.Serialize(writer);
            }
            

}

public override void Deserialize(IDataReader reader)
{

markAuthorId = reader.ReadInt();
            markSpellId = reader.ReadInt();
            if (markSpellId < 0)
                throw new Exception("Forbidden value on markSpellId = " + markSpellId + ", it doesn't respect the following condition : markSpellId < 0");
            markId = reader.ReadShort();
            markType = reader.ReadSByte();
            var limit = reader.ReadUShort();
            cells = new Types.GameActionMarkedCell[limit];
            for (int i = 0; i < limit; i++)
            {
                 cells[i] = new Types.GameActionMarkedCell();
                 cells[i].Deserialize(reader);
            }
            

}


}


}