using Arcane.Base.Entities;
using Arcane.Game.Entities;
using Arcane.Game.Wrappers;
using Arcane.Protocol.Datacenter;
using Arcane.Protocol.Enums;
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
            var character = characterWrapper.Character;
            return new CharacterBaseInformations
            {
                id = character.Id,
                breed = character.Breed.ToSByte(),
                entityLook = characterWrapper.EntityLook,
                level = characterWrapper.GetLevel(),
                name = character.Name,
                sex = character.Sex.ToBoolean()
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

        internal static void UpdateLastSelection(this CharacterEntity character, DateTime lastSelect)
        {
            using (new SessionScope())
            {
                character.LastSelection = lastSelect;
                character.Update();
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

        public static Breed GetTemplateBreed(this CharacterEntity character)
        {
            return GameDataManager.Instance.GetObject<Breed>((int)character.Breed);
        }

        public static Breed GetTemplateBreed(this PlayableBreedEnum breed)
        {
            return GameDataManager.Instance.GetObject<Breed>((int)breed);
        }

        public static short[] GetTemplateSkins(this CharacterEntity character)
        {
            var breed = GetTemplateBreed(character);
            var templateLook = (character.Sex == SexEnum.Female ? breed.femaleLook : breed.maleLook).ToEntityLook();
            return templateLook.skins;
        }
    }
}
