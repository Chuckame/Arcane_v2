using Arcane.Protocol.Datacenter;
using Dofus.Files.Dofus.Files.Maps;
using Dofus.Files.GameData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Game.Wrappers
{
    public class MapWrapper
    {
        public MapFile TemplateMap { get; }
        public MapPosition TemplateMapPosition { get; }
        public SubArea TemplateSubArea { get; }
        public SuperArea TemplateSuperArea { get; }

        public MapWrapper(MapFile map)
        {
            TemplateMap = map;
            TemplateMapPosition = GameDataManager.Instance.GetObject<MapPosition>((int)map.Id);
            TemplateSubArea = GameDataManager.Instance.GetObject<SubArea>(map.SubareaId);
            TemplateSuperArea = GameDataManager.Instance.GetObject<SuperArea>(TemplateSubArea.areaId);
        }
    }
}
