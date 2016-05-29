using Arcane.Game.Wrappers;
using Arcane.Protocol.Messages;
using Arcane.Protocol.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Game.Helpers
{
    public static class MapHelper
    {
        public static MapComplementaryInformationsDataMessage ToMapComplementaryInformationsDataMessage(this MapWrapper map)
        {
            return new MapComplementaryInformationsDataMessage((short)map.TemplateSubArea.id, map.Id, map.AlignmentSide.ToSByte(), map.GetHousesInformations(), map.GetGameRolePlayActorInformations(), map.GetInteractiveElement(), map.GetStatedElement(), map.GetMapObstacle(), map.GetFightCommonInformations());
        }

        public static HouseInformations[] GetHousesInformations(this MapWrapper map)
        {
            return new HouseInformations[0];
        }

        public static GameRolePlayActorInformations[] GetGameRolePlayActorInformations(this MapWrapper map)
        {
            return map.Clients.Select(c => c.Character.ToGameRolePlayActorInformations()).ToArray();
        }

        public static InteractiveElement[] GetInteractiveElement(this MapWrapper map)
        {
            var res = new LinkedList<InteractiveElement>();
            foreach (var layer in map.TemplateMap.Layers)
            {
                foreach (var cell in layer.Value.Cells)
                {
                    foreach (var element in cell.Value.Elements)
                    {
                        if (element.ElementType == Dofus.Files.Dofus.Files.Maps.Types.ElementTypesEnum.GRAPHICAL)
                        {
                            if ((element as Dofus.Files.Dofus.Files.Maps.Elements.GraphicalMapElement).IsIdentified())
                            {
                                res.AddLast(new InteractiveElement((int)(element as Dofus.Files.Dofus.Files.Maps.Elements.GraphicalMapElement).Identifier, 0, new InteractiveElementSkill[] {
                                    new InteractiveElementSkill(184, 1)
                            }, new InteractiveElementSkill[0]));
                            }
                        }
                    }
                }
            }
            return res.ToArray();
        }

        public static StatedElement[] GetStatedElement(this MapWrapper map)
        {
            return new StatedElement[0];
        }

        public static MapObstacle[] GetMapObstacle(this MapWrapper map)
        {
            return new MapObstacle[0];
        }

        public static FightCommonInformations[] GetFightCommonInformations(this MapWrapper map)
        {
            return new FightCommonInformations[0];
        }
    }
}
