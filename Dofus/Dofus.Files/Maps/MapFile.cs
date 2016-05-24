using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dofus.Files.Common;
using Dofus.IO;
using Dofus.Files.Maps.Types;
using Dofus.Files.Dofus.Files.Maps.Types;
using System.Drawing;
using Dofus.Files.Utils;
using System.IO;
using Dofus.Files.Dofus.Files.Common;

namespace Dofus.Files.Dofus.Files.Maps
{
    public class MapFile : AbstractDofusFile, IMapFile
    {
        public override DofusFileTypeEnum DofusFileType
        {
            get
            {
                return DofusFileTypeEnum.Map;
            }
        }

        public byte MapVersion { get; set; }
        public uint Id { get; set; }
        public bool Encrypted { get; set; }
        public byte EncryptionVersion { get; set; }
        public uint RelativeId { get; set; }
        public MapTypeEnum MapType { get; set; }
        public int SubareaId { get; set; }
        public int TopNeighbourId { get; set; }
        public int BottomNeighbourId { get; set; }
        public int LeftNeighbourId { get; set; }
        public int RightNeighbourId { get; set; }
        public int ShadowBonusOnEntities { get; set; }
        public byte BackgroundRed { get; set; }
        public byte BackgroundGreen { get; set; }
        public byte BackgroundBlue { get; set; }
        public double ZoomScale { get; set; }
        public short ZoomOffsetX { get; set; }
        public short ZoomOffsetY { get; set; }
        public bool UseLowPassFilter { get; set; }
        public bool UseReverb { get; set; }
        public int PresetId { get; set; }
        public int GroundCRC { get; set; }
        public ICollection<MapFixture> BackgroundFixtures { get; }
        public ICollection<MapFixture> ForegroundFixtures { get; }
        public IDictionary<LayerTypeEnum, MapLayer> Layers { get; }
        public IDictionary<short, MapCellData> Cells { get; }

        public Color BackgroundColor
        {
            get
            {
                return Color.FromArgb(this.BackgroundRed, this.BackgroundGreen, this.BackgroundBlue);
            }
            set
            {
                this.BackgroundRed = value.R;
                this.BackgroundGreen = value.G;
                this.BackgroundBlue = value.B;
            }
        }

        public static readonly byte[] ENCRIPTION_KEY = Encoding.Default.GetBytes("649ae451ca33ec53bbcbcc33becf15f4");
        public static readonly byte HEADER = 77;

        public MapFile()
        {
            this.BackgroundFixtures = new LinkedList<MapFixture>();
            this.ForegroundFixtures = new LinkedList<MapFixture>();
            this.Layers = new Dictionary<LayerTypeEnum, MapLayer>();
            this.Cells = new Dictionary<short, MapCellData>();
        }

        public override void FromRaw(IDataReader reader)
        {
            var header = reader.ReadByte();
            if (header != HEADER)
            {
                try
                {
                    var data = reader.Data;
                    reader = DofusIOUtils.CreateBigEndianReader(ZipHelper.Uncompress(data));

                    header = reader.ReadByte();
                    if (header != HEADER)
                        throw new FileLoadException("Wrong header file");
                }
                catch (Exception e)
                {
                    throw new FileLoadException("File is invalid.", e);
                }
            }
            #region base
            this.MapVersion = reader.ReadByte();
            this.Id = reader.ReadUInt();
            if (this.MapVersion >= 7)
            {
                this.Encrypted = reader.ReadBoolean();
                this.EncryptionVersion = reader.ReadByte();
                var dataLen = reader.ReadInt();
                if (this.Encrypted)
                {
                    reader = DofusIOUtils.CreateBigEndianReader(CryptHelper.DecryptXor(reader.ReadBytes(dataLen), ENCRIPTION_KEY));
                }
            }
            this.RelativeId = reader.ReadUInt();
            this.MapType = (MapTypeEnum)reader.ReadByte();
            if (!Enum.IsDefined(typeof(MapTypeEnum), MapType))
                throw new FileLoadException($"Bad mapType '{MapType}'.");
            this.SubareaId = reader.ReadInt();
            this.TopNeighbourId = reader.ReadInt();
            this.BottomNeighbourId = reader.ReadInt();
            this.LeftNeighbourId = reader.ReadInt();
            this.RightNeighbourId = reader.ReadInt();
            this.ShadowBonusOnEntities = reader.ReadInt();
            if (this.MapVersion >= 3)
            {
                this.BackgroundRed = reader.ReadByte();
                this.BackgroundGreen = reader.ReadByte();
                this.BackgroundBlue = reader.ReadByte();
            }
            if (this.MapVersion >= 4)
            {
                this.ZoomScale = reader.ReadUShort() / 100.0;
                this.ZoomOffsetX = reader.ReadShort();
                this.ZoomOffsetY = reader.ReadShort();
            }
            else
            {
                this.ZoomScale = 1.0;
            }
            this.UseLowPassFilter = reader.ReadByte() == 1;
            this.UseReverb = reader.ReadBoolean();
            if (this.UseReverb)
            {
                this.PresetId = reader.ReadInt();
            }
            else
            {
                this.PresetId = -1;
            }
            #endregion

            var backgroundsCount = reader.ReadByte();
            BackgroundFixtures.Clear();
            for (int i = 0; i < backgroundsCount; ++i)
            {
                var fixture = new MapFixture();
                fixture.ReadFrom(reader);
                this.BackgroundFixtures.Add(fixture);
            }

            var foregroundsCount = reader.ReadByte();
            ForegroundFixtures.Clear();
            for (int i = 0; i < foregroundsCount; ++i)
            {
                var fixture = new MapFixture();
                fixture.ReadFrom(reader);
                this.ForegroundFixtures.Add(fixture);
            }

            reader.ReadInt();//unused
            this.GroundCRC = reader.ReadInt();

            var layersCount = reader.ReadByte();
            this.Layers.Clear();
            for (int i = 0; i < layersCount; ++i)
            {
                var layer = new MapLayer(this);
                layer.ReadFrom(reader);
                this.Layers.Add(layer.LayerId, layer);
            }

            this.Cells.Clear();
            for (short currentCellDataIndex = 0; currentCellDataIndex < AtouinConstants.MAP_CELLS_COUNT; ++currentCellDataIndex)
            {
                var cellData = new MapCellData(this);
                cellData.ReadFrom(reader);
                this.Cells.Add(currentCellDataIndex, cellData);
            }
        }

        public override void ToRaw(IDataWriter writer)
        {
            using (var firstWriter = DofusIOUtils.CreateBigEndianWriter())
            using (var generalWriter = DofusIOUtils.CreateBigEndianWriter())
            {
                firstWriter.WriteByte(HEADER);
                firstWriter.WriteByte(this.MapVersion);
                firstWriter.WriteUInt(this.Id);

                generalWriter.WriteUInt(this.RelativeId);
                generalWriter.WriteByte((byte)this.MapType);
                generalWriter.WriteInt(this.SubareaId);
                generalWriter.WriteInt(this.TopNeighbourId);
                generalWriter.WriteInt(this.BottomNeighbourId);
                generalWriter.WriteInt(this.LeftNeighbourId);
                generalWriter.WriteInt(this.RightNeighbourId);
                generalWriter.WriteInt(this.ShadowBonusOnEntities);
                if (this.MapVersion >= 3)
                {
                    generalWriter.WriteByte(this.BackgroundRed);
                    generalWriter.WriteByte(this.BackgroundGreen);
                    generalWriter.WriteByte(this.BackgroundBlue);
                }
                if (this.MapVersion >= 4)
                {
                    generalWriter.WriteUShort((ushort)(this.ZoomScale * 100.0));
                    generalWriter.WriteShort(this.ZoomOffsetX);
                    generalWriter.WriteShort(this.ZoomOffsetY);
                }
                generalWriter.WriteBoolean(this.UseLowPassFilter);
                generalWriter.WriteBoolean(this.UseReverb);
                if (this.UseReverb)
                {
                    generalWriter.WriteInt(this.PresetId);
                }
                else
                {
                    this.PresetId = -1;
                }

                generalWriter.WriteByte((byte)this.BackgroundFixtures.Count);
                foreach (var back in this.BackgroundFixtures)
                    back.WriteTo(generalWriter);

                generalWriter.WriteByte((byte)this.ForegroundFixtures.Count);
                foreach (var back in this.ForegroundFixtures)
                    back.WriteTo(generalWriter);

                generalWriter.WriteInt(0);//unused
                generalWriter.WriteInt(this.GroundCRC);

                generalWriter.WriteByte((byte)this.Layers.Count);
                foreach (var back in this.Layers.Values)
                    back.WriteTo(generalWriter);

                if (this.Cells.Count != AtouinConstants.MAP_CELLS_COUNT)
                    throw new InvalidDataException($"{nameof(Cells)} array must have {AtouinConstants.MAP_CELLS_COUNT} cells.");
                for (short cellId = 0; cellId < AtouinConstants.MAP_CELLS_COUNT; ++cellId)
                {
                    if (this.Cells.ContainsKey(cellId))
                    {
                        this.Cells[cellId].WriteTo(generalWriter);
                    }
                    else
                    {
                        throw new InvalidDataException($"Missing MapCellData on cell id {cellId}.");
                    }
                }

                var data = generalWriter.Data;
                if (this.MapVersion >= 7)
                {
                    firstWriter.WriteBoolean(this.Encrypted);
                    firstWriter.WriteByte(this.EncryptionVersion);
                    firstWriter.WriteInt(data.Length);
                    if (this.Encrypted)
                    {
                        data = CryptHelper.EncryptXor(data, ENCRIPTION_KEY);
                    }
                }

                writer.WriteBytes(firstWriter.Data);
                writer.WriteBytes(data);
            }
        }

        public override string ToString()
        {
            return $"MapFile#{Id}";
        }
    }
}
