using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dofus.IO;
using Dofus.Files.Dofus.Files.Maps.Types;

namespace Dofus.Files.Dofus.Files.Maps.Elements
{
    public class SoundMapElement : IMapElement
    {
        public int SoundId { get; set; }
        public short BaseVolume { get; set; }
        public int FullVolumeDistance { get; set; }
        public int NullVolumeDistance { get; set; }
        public short MinDelayBetweenLoops { get; set; }
        public short MaxDelayBetweenLoops { get; set; }
        public MapFile Map { get; }

        public ElementTypesEnum ElementType
        {
            get
            {
                return ElementTypesEnum.SOUND;
            }
        }

        public SoundMapElement(MapFile map)
        {
            this.Map = map;
        }

        public void ReadFrom(IDataReader reader)
        {
            this.SoundId = reader.ReadInt();
            this.BaseVolume = reader.ReadShort();
            this.FullVolumeDistance = reader.ReadInt();
            this.NullVolumeDistance = reader.ReadInt();
            this.MinDelayBetweenLoops = reader.ReadShort();
            this.MaxDelayBetweenLoops = reader.ReadShort();
        }

        public void WriteTo(IDataWriter writer)
        {
            writer.WriteInt(this.SoundId);
            writer.WriteShort(this.BaseVolume);
            writer.WriteInt(this.FullVolumeDistance);
            writer.WriteInt(this.NullVolumeDistance);
            writer.WriteShort(this.MinDelayBetweenLoops);
            writer.WriteShort(this.MaxDelayBetweenLoops);
        }
    }
}
