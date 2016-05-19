// Generated on 05/16/2016 23:27:22
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

    public class DebugHighlightCellsMessage : AbstractMessage
    {

        public const uint Id = 2001;
        public override uint MessageId
        {
            get { return Id; }
        }

        public int color;
        public short[] cells;


        public DebugHighlightCellsMessage()
        {
        }

        public DebugHighlightCellsMessage(int color, short[] cells)
        {
            this.color = color;
            this.cells = cells;
        }


        public override void Serialize(IDataWriter writer)
        {

            writer.WriteInt(color);
            writer.WriteUShort((ushort)cells.Length);
            foreach (var entry in cells)
            {
                writer.WriteShort(entry);
            }


        }

        public override void Deserialize(IDataReader reader)
        {

            color = reader.ReadInt();
            var limit = reader.ReadUShort();
            cells = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                cells[i] = reader.ReadShort();
            }


        }


    }


}