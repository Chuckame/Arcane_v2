using Arcane.Base.Entities;
using Arcane.Game.Entities;
using Arcane.Game.Helpers;
using Arcane.Game.Wrappers.Character.Types;
using Arcane.Protocol.Enums;
using Arcane.Protocol.Types;
using Castle.ActiveRecord;
using Dofus.Files.GameData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Game.Wrappers
{
    public class CharacterWrapper : INotifyPropertyChanged
    {
        private CharacterEntity Character { get; }
        public GameContextEnum CurrentContext { get; set; }
        public EntityLook EntityLook { get; private set; }
        //public Map CurrentMap { get; set; }

        public event Action<CharacterWrapper> OnLookUpdated;
        public event Action<CharacterWrapper> OnConnectedInGame;
        public event Action<CharacterWrapper> OnExperienceChanged;
        public event Action<CharacterWrapper> OnLevelUp;
        public event Action<CharacterWrapper> OnLevelChanged;
        public event Action<CharacterWrapper> OnManualLevelChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        private short[] _basicSkins;
        private byte _level;

        private CharacterWrapper(CharacterEntity character)
        {
            Character = character;

            Restrictions = new ActorRestrictionsInformations();
            Alignment = new Alignment() { Side = AlignmentSideEnum.ALIGNMENT_WITHOUT };
            Disposition = new Disposition() { CellId = 371, Direction = DirectionsEnum.DIRECTION_SOUTH_WEST };
            Title = new Title { Id = 0, Params = "" };
            InitValues();
            InitEvents();
        }

        private void InitEvents()
        {
            OnManualLevelChanged += CharacterWrapper_OnManualLevelChanged;
            OnExperienceChanged += CharacterWrapper_OnExperienceChanged;
            PropertyChanged += CharacterWrapper_PropertyChanged;
        }

        private void InitValues()
        {
            _level = ExperienceStepHelper.GetCharacterLevelByExp(Experience);
            _basicSkins = this.GetTemplateSkins();
            UpdateEntityLook();
        }

        #region internal handled events
        private static void CharacterWrapper_OnExperienceChanged(CharacterWrapper wrapper)
        {
            var probablyNewLevel = ExperienceStepHelper.GetCharacterLevelByExp(wrapper.Experience);
            if (probablyNewLevel > wrapper._level)
            {
                do
                {
                    wrapper._level++;
                    wrapper.OnLevelUp?.Invoke(wrapper);
                } while (wrapper._level <= probablyNewLevel);
                wrapper.OnLevelChanged?.Invoke(wrapper);
            }
            else if (probablyNewLevel < wrapper._level)
            {
                wrapper._level = probablyNewLevel;
                wrapper.OnLevelChanged?.Invoke(wrapper);
            }
        }

        private void CharacterWrapper_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender == this)
            {
                switch (e.PropertyName)
                {
                    case nameof(BonesId):
                    case nameof(Breed):
                    case nameof(Colors):
                    case nameof(Name):
                    case nameof(Scale):
                    case nameof(Sex):
                        UpdateEntityLook();
                        break;
                    default:
                        break;
                }
            }
        }

        private static void CharacterWrapper_OnManualLevelChanged(CharacterWrapper wrapper)
        {
            wrapper.Experience = ExperienceStepHelper.GetCharacterExpByLevel(wrapper.Level);
        }
        #endregion

        #region properties
        public byte Level
        {
            get
            {
                return _level;
            }
            set
            {
                if (_level != value)
                {
                    _level = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Level)));
                    OnManualLevelChanged?.Invoke(this);
                }
            }
        }
        public Alignment Alignment { get; }
        public Disposition Disposition { get; }
        #endregion

        #region wrapped properties
        public double Experience
        {
            get
            {
                return Character.Experience;
            }
            set
            {
                if (Character.Experience != value)
                {
                    Character.Experience = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Experience)));
                    OnExperienceChanged?.Invoke(this);
                }
            }
        }

        public short BonesId
        {
            get
            {
                return Character.BonesId;
            }
            set
            {
                if (Character.BonesId != value)
                {
                    Character.BonesId = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BonesId)));
                }
            }
        }

        public PlayableBreedEnum Breed
        {
            get
            {
                return Character.Breed;
            }
            set
            {
                if (Character.Breed != value)
                {
                    Character.Breed = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Breed)));
                }
            }
        }

        public int[] Colors
        {
            get
            {
                return Character.Colors;
            }
            set
            {
                if (Character.Colors != value)
                {
                    Character.Colors = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Colors)));
                }
            }
        }

        public DateTime LastSelectionDate
        {
            get
            {
                return Character.LastSelection;
            }
            set
            {
                if (Character.LastSelection != value)
                {
                    Character.LastSelection = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LastSelectionDate)));
                }
            }
        }

        public string Name
        {
            get
            {
                return Character.Name;
            }
            set
            {
                if (Character.Name != value)
                {
                    Character.Name = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
                }
            }
        }

        public short Scale
        {
            get
            {
                return Character.Scale;
            }
            set
            {
                if (Character.Scale != value)
                {
                    Character.Scale = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Scale)));
                }
            }
        }

        public SexEnum Sex
        {
            get
            {
                return Character.Sex;
            }
            set
            {
                if (Character.Sex != value)
                {
                    Character.Sex = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Sex)));
                }
            }
        }

        public Account Owner
        {
            get
            {
                return Character.Owner;
            }
        }

        public int Id
        {
            get
            {
                return Character.Id;
            }
        }

        public ActorRestrictionsInformations Restrictions { get; }
        public Title Title { get; }
        #endregion

        #region CRUD
        public void Save()
        {
            Character.Save();
        }
        public void Delete()
        {
            Character.Delete();
        }
        #endregion

        public static CharacterWrapper FromCharacterEntity(CharacterEntity character)
        {
            return new CharacterWrapper(character);
        }

        public void UpdateEntityLook()
        {
            EntityLook = new EntityLook(1, GetSkins(), CharacterHelper.SerializeColors(Character.Colors), new short[] { Character.Scale }, GetSubEntities());
            OnLookUpdated?.Invoke(this);
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
            }
        }
    }
}
