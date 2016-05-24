using Dofus.Files.Dofus.Files.Common;
using Dofus.Files.Dofus.Files.Maps.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dofus.IO;
using System.Collections.ObjectModel;
using Dofus.Files.Dofus.Files.Maps.Types;

namespace Dofus.Files.Dofus.Files.Maps
{
    public class MapCell : IReadable, IWritable
    {
        public short CellId { get; set; }
        public ICollection<IMapElement> Elements { get; }
        public MapFile Map { get; }

        public MapCell(MapFile map)
        {
            this.Map = map;
            Elements = new LinkedList<IMapElement>();
        }

        public void ReadFrom(IDataReader reader)
        {
            this.CellId = reader.ReadShort();
            var elementsCount = reader.ReadShort();
            this.Elements.Clear();
            for (int i = 0; i < elementsCount; i++)
            {
                var elType = (ElementTypesEnum)reader.ReadByte();
                var element = MapElementFactory.GetElementFromType(elType, Map);
                element.ReadFrom(reader);
                this.Elements.Add(element);
            }
        }

        public void WriteTo(IDataWriter writer)
        {
            writer.WriteShort(this.CellId);
            writer.WriteShort((short)this.Elements.Count);
            foreach (var element in this.Elements)
            {
                writer.WriteByte((byte)element.ElementType);
                element.WriteTo(writer);
            }
        }
    }
}
