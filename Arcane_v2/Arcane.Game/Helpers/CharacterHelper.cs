using Arcane.Base.Entities;
using Arcane.Game.Entities;
using Arcane.Game.Managers;
using Arcane.Game.Network;
using Arcane.Game.Wrappers;
using Arcane.Protocol.Datacenter;
using Arcane.Protocol.Enums;
using Arcane.Protocol.Messages;
using Arcane.Protocol.Types;
using Castle.ActiveRecord;
using Dofus.Files.GameData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Game.Helpers
{
    public static class CharacterHelper
    {
        public static CharacterBaseInformations ToCharacterBaseInformations(this CharacterWrapper characterWrapper)
        {
            return new CharacterBaseInformations
            {
                id = characterWrapper.Id,
                breed = characterWrapper.Breed.ToSByte(),
                entityLook = characterWrapper.EntityLook,
                level = characterWrapper.Level,
                name = characterWrapper.Name,
                sex = characterWrapper.Sex.ToBoolean()
            };
        }

        public static LinkedList<CharacterWrapper> GetCharacters(int accountId)
        {
            var charsInfos = new LinkedList<CharacterWrapper>();
            using (new SessionScope())
            {
                var characters = CharacterEntity.Queryable.Where(c => c.Owner.Id == accountId).OrderByDescending(c => c.LastSelection);
                foreach (var character in characters)
                {
                    charsInfos.AddLast(CharacterWrapper.FromCharacterEntity(character));
                }
            }
            return charsInfos;
        }

        public static void UpdateLastSelectionDate(this CharacterWrapper character, DateTime lastSelect)
        {
            using (new SessionScope())
            {
                character.LastSelectionDate = lastSelect;
                character.Save();
            }
        }

        public static bool IsCharacterOwnerNicknameExists(string name)
        {
            using (new SessionScope())
            {
                var sName = name.ToLowerInvariant();
                return CharacterEntity.Queryable.Any(c => c.Owner.Nickname.ToLowerInvariant().Equals(sName));
            }
        }

        public static Breed GetTemplateBreed(this CharacterWrapper character)
        {
            return GameDataManager.Instance.GetObject<Breed>((int)character.Breed);
        }

        public static Breed GetTemplateBreed(this PlayableBreedEnum breed)
        {
            return GameDataManager.Instance.GetObject<Breed>((int)breed);
        }

        public static short[] GetTemplateSkins(this CharacterWrapper character)
        {
            var breed = GetTemplateBreed(character);
            var templateLook = (character.Sex == SexEnum.Female ? breed.femaleLook : breed.maleLook).ToEntityLook();
            return templateLook.skins;
        }

        public static GameRolePlayActorInformations ToGameRolePlayActorInformations(this CharacterWrapper characterWrapper)
        {
            return new GameRolePlayCharacterInformations(characterWrapper.Id, characterWrapper.EntityLook, characterWrapper.ToEntityDispositionInformations(), characterWrapper.Name, characterWrapper.ToHumanInformations(), characterWrapper.ToActorAlignmentInformations());
        }

        public static IdentifiedEntityDispositionInformations ToEntityDispositionInformations(this CharacterWrapper wrapper)
        {
            return new IdentifiedEntityDispositionInformations(wrapper.Disposition.CellId, wrapper.Disposition.Direction.ToSByte(), wrapper.Id);
        }

        public static ActorOrientation ToActorOrientation(this CharacterWrapper wrapper)
        {
            return new ActorOrientation(wrapper.Id, wrapper.Disposition.Direction.ToSByte());
        }

        public static HumanInformations ToHumanInformations(this CharacterWrapper wrapper)
        {
            return new HumanInformations(new EntityLook[0], 0, 0, wrapper.Restrictions, wrapper.Title.Id, wrapper.Title.Params);
        }

        public static ActorAlignmentInformations ToActorAlignmentInformations(this CharacterWrapper wrapper)
        {
            return new ActorAlignmentInformations(wrapper.Alignment.Side.ToSByte(), wrapper.Alignment.Value, wrapper.Alignment.Grade, wrapper.Alignment.Dishonor, wrapper.Alignment.CharacterPower);
        }

        public static int[] SerializeColors(IList<int> colors)
        {
            var list = new List<int>();

            for (int i = 0; i < colors.Count; i++)
                list.Insert(i, colors[i] | (i + 1) * 0x1000000);

            return list.ToArray();
        }

        public static void ChangeMap(this GameClient client, int newMapId, short? targetCellId = null)
        {
            if (client.Character.CurrentMap != null)
                client.Character.CurrentMap.RemoveClient(client);
            var newMap = MapManager.Instance.GetMap(newMapId);
            short cellId;
            if (targetCellId.HasValue)
            {
                cellId = targetCellId.Value;
            }
            else
            {
                cellId = client.Character.CellId;
                if (client.Character.CurrentMap.TemplateMap.LeftNeighbourId == newMapId)
                    cellId += 13;
                else if (client.Character.CurrentMap.TemplateMap.RightNeighbourId == newMapId)
                    cellId -= 13;
                else if (client.Character.CurrentMap.TemplateMap.TopNeighbourId == newMapId)
                    cellId += 532;
                else if (client.Character.CurrentMap.TemplateMap.BottomNeighbourId == newMapId)
                    cellId -= 532;
            }
            client.Character.CellId = cellId;
            client.Character.CurrentMap = newMap;
            client.Character.Save();
            newMap.AddClient(client);
            client.SendMessage(new CurrentMapMessage(newMapId, Config.MapKey));
        }

        public static void MoveOnMap(this GameClient client, short[] path)
        {
            client.Character.CurrentMap.MoveClient(client, path);
        }
    }
}
