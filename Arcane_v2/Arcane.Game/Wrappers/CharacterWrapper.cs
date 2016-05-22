using Arcane.Game.Entities;
using Arcane.Protocol.Types;
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
        public EntityLook EntityLook { get; private set; }
        public event Action<CharacterWrapper> OnLookUpdated;

        private CharacterWrapper(CharacterEntity character)
        {
            Character = character;
            Character.PropertyChanged += Character_PropertyChanged;
            UpdateEntityLook();
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
            EntityLook = new EntityLook(Character.BonesId, GetSkins(), Character.Colors, new short[] { Character.Scale }, GetSubEntities());
            OnLookUpdated?.Invoke(this);
        }

        private SubEntity[] GetSubEntities()
        {
            return new SubEntity[0];
        }

        private short[] GetSkins()
        {
            return new short[0];
        }
    }
}
