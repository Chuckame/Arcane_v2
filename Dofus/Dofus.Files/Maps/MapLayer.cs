using Dofus.Files.Dofus.Files.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dofus.IO;
using Dofus.Files.Dofus.Files.Maps.Types;

namespace Dofus.Files.Dofus.Files.Maps
{
    public class MapLayer : IReadable, IWritable
    {
        public LayerTypeEnum LayerId { get; set; }
        public IDictionary<short, MapCell> Cells { get; }
        public MapFile Map { get; }

        public MapCell this[short cellId]
        {
            get
            {
                return Cells[cellId];
            }
            set
            {
                Cells[cellId] = value;
            }
        }
        public MapLayer(MapFile map)
        {
            Map = map;
            Cells = new Dictionary<short, MapCell>();
        }

        public void ReadFrom(IDataReader reader)
        {
            this.LayerId = (LayerTypeEnum)reader.ReadInt();
            var cellsCount = reader.ReadShort();
            this.Cells.Clear();
            for (int i = 0; i < cellsCount; ++i)
            {
                var _cell = new MapCell(Map);
                _cell.ReadFrom(reader);
                this.Cells.Add(_cell.CellId, _cell);
            }
        }

        public void WriteTo(IDataWriter writer)
        {
            writer.WriteInt((int)this.LayerId);
            writer.WriteShort((short)this.Cells.Count);
            foreach (var cell in this.Cells.Values)
            {
                cell.WriteTo(writer);
            }
        }
    }
}
