using System.Collections.Generic;
using System.Drawing;
using Dofus.Files.Dofus.Files.Maps.Types;
using Dofus.Files.Maps.Types;
using Dofus.IO;

namespace Dofus.Files.Dofus.Files.Maps
{
    public interface IMapFile : IDofusFile
    {
        byte BackgroundBlue { get; set; }
        Color BackgroundColor { get; set; }
        ICollection<MapFixture> BackgroundFixtures { get; }
        byte BackgroundGreen { get; set; }
        byte BackgroundRed { get; set; }
        int BottomNeighbourId { get; set; }
        IDictionary<short, MapCellData> Cells { get; }
        bool Encrypted { get; set; }
        byte EncryptionVersion { get; set; }
        ICollection<MapFixture> ForegroundFixtures { get; }
        int GroundCRC { get; set; }
        uint Id { get; set; }
        IDictionary<LayerTypeEnum, MapLayer> Layers { get; }
        int LeftNeighbourId { get; set; }
        MapTypeEnum MapType { get; set; }
        byte MapVersion { get; set; }
        int PresetId { get; set; }
        uint RelativeId { get; set; }
        int RightNeighbourId { get; set; }
        int ShadowBonusOnEntities { get; set; }
        int SubareaId { get; set; }
        int TopNeighbourId { get; set; }
        bool UseLowPassFilter { get; set; }
        bool UseReverb { get; set; }
        short ZoomOffsetX { get; set; }
        short ZoomOffsetY { get; set; }
        double ZoomScale { get; set; }
    }
}