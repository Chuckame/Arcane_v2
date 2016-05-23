using Arcane.Base.Entities;
using Arcane.Game.Entities;
using Arcane.Game.Helpers;
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

namespace Arcane.Game.Wrappers
{
    public class CharacterWrapper
    {
        public CharacterEntity Character { get; }
        public GameContextEnum CurrentContext { get; set; }
        public EntityLook EntityLook { get; private set; }
        public event Action<CharacterWrapper> OnLookUpdated;
        public event Action<CharacterWrapper, Account> OnFriendAdded;
        private short[] _basicSkins;

        private CharacterWrapper(CharacterEntity character)
        {
            Character = character;
            Character.PropertyChanged += Character_PropertyChanged;

            _basicSkins = character.GetTemplateSkins();

            UpdateEntityLook();
        }

        public byte GetLevel()
        {
            return ExperienceStepHelper.GetCharacterLevelByExp(Character.Experience);
        }

        private void Character_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (sender == Character)
            {
                switch (e.PropertyName)
                {
                    case nameof(Character.BonesId):
                    case nameof(Character.Breed):
                    case nameof(Character.Colors):
                    case nameof(Character.Name):
                    case nameof(Character.Scale):
                    case nameof(Character.Sex):
                        UpdateEntityLook();
                        break;
                    default:
                        break;
                }
            }
        }

        public static CharacterWrapper FromCharacterEntity(CharacterEntity character)
        {
            return new CharacterWrapper(character);
        }

        public void UpdateEntityLook()
        {
            EntityLook = new EntityLook(1, GetSkins(), SerializeColors(Character.Colors), new short[] { Character.Scale }, GetSubEntities());
            OnLookUpdated?.Invoke(this);
        }

        public static int[] SerializeColors(IList<int> indexedColors)
        {
            var list = new List<int>();

            for (int i = 0; i < indexedColors.Count; i++)
                list.Insert(i, indexedColors[i] | (i + 1) * 0x1000000);

            return list.ToArray();
        }

        private SubEntity[] GetSubEntities()
        {
            return new SubEntity[0];
        }

        private short[] GetSkins()
        {
            return _basicSkins;
        }

        public void AddFriend(Account account)
        {
            if (!Character.Owner.Friends.Contains(account))
            {
                using (new SessionScope())
                {
                    Character.Owner.Friends.Add(account);
                    Character.Owner.Update();
                }
                OnFriendAdded?.Invoke(this, account);
            }
        }
    }
}
