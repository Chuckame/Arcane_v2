using Arcane.Game.Entities;
using Arcane.Game.Wrappers;
using Arcane.Protocol.Enums;
using Arcane.Protocol.Types;
using Castle.ActiveRecord;
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
                level = ExperienceStepHelper.GetCharacterLevelByExp(character.Experience),
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
    }
}
