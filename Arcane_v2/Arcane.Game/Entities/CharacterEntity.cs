using Arcane.Base.Entities;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Enums;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Arcane.Game.Entities
{
    [ActiveRecord("characters", "heart_emu_game")]
    public class CharacterEntity : ActiveRecordLinqBase<CharacterEntity>, INotifyPropertyChanged
    {
        short _bonesId;
        PlayableBreedEnum _breed;
        int[] _colors = new int[0];
        double _experience;
        string _name;
        Account _owner;
        short _scale;
        SexEnum _sex;
        private DateTime _lastSelection;
        private int _mapId;
        private DirectionsEnum _direction;
        private short _cellId;

        public event PropertyChangedEventHandler PropertyChanged;

        [Property("bones_id", NotNull = true)]
        public short BonesId
        {
            get
            {
                return _bonesId;
            }

            set
            {
                if (_bonesId != value)
                {
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BonesId)));
                    _bonesId = value;
                }
            }
        }

        [Property("breed", NotNull = true)]
        public PlayableBreedEnum Breed
        {
            get
            {
                return _breed;
            }
            set
            {
                if (_breed != value)
                {
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Breed)));
                    _breed = value;
                }
            }
        }

        [Property("colors", NotNull = true, Length = 100)]
        private string DbColors
        {
            get
            {
                return _colors.Dump('|');
            }
            set
            {
                if (DbColors != value)
                {
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Colors)));
                    _colors = value.ParseToArray<int>('|');
                }
            }
        }

        public int[] Colors
        {
            get
            {
                return _colors;
            }
            set
            {
                if (_colors != value)
                {
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Colors)));
                    _colors = value;
                }
            }
        }

        [Property("experience", NotNull = true)]
        public double Experience
        {
            get
            {
                return _experience;
            }
            set
            {
                if (_experience != value)
                {
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Experience)));
                    _experience = value;
                }
            }
        }

        [PrimaryKey("character_id", Generator = PrimaryKeyType.Identity)]
        public int Id { get; private set; }

        [Property("name", NotNull = true)]
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name != value)
                {
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
                    _name = value;
                }
            }
        }

        [BelongsTo("owner_id", NotNull = true)]
        public Account Owner
        {
            get
            {
                return _owner;
            }
            set
            {
                if (_owner != value)
                {
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Owner)));
                    _owner = value;
                }
            }
        }

        [Property("scale", NotNull = true)]
        public short Scale
        {
            get
            {
                return _scale;
            }
            set
            {
                if (_scale != value)
                {
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Scale)));
                    _scale = value;
                }
            }
        }

        [Property("sex", NotNull = true)]
        public SexEnum Sex
        {
            get
            {
                return _sex;
            }
            set
            {
                if (_sex != value)
                {
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Sex)));
                    _sex = value;
                }
            }
        }

        [Property("lastSelection")]
        public DateTime LastSelection
        {
            get
            {
                return _lastSelection;
            }
            set
            {
                if (_lastSelection != value)
                {
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LastSelection)));
                    _lastSelection = value;
                }
            }
        }

        [Property("mapId")]
        public int MapId
        {
            get
            {
                return _mapId;
            }
            set
            {
                if (_mapId != value)
                {
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MapId)));
                    _mapId = value;
                }
            }
        }

        [Property("direction")]
        public DirectionsEnum Direction
        {
            get
            {
                return _direction;
            }
            set
            {
                if (_direction != value)
                {
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Direction)));
                    _direction = value;
                }
            }
        }

        [Property("cellId")]
        public short CellId
        {
            get
            {
                return _cellId;
            }
            set
            {
                if (_cellId != value)
                {
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CellId)));
                    _cellId = value;
                }
            }
        }
    }
}
