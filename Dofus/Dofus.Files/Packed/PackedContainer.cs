using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dofus.Files.Packed
{
    public class PackedContainer
    {
        private string _mName;
        public string Name
        {
            get
            {
                return _mName;
            }
            set
            {
                _mName = PackedContainerHelper.ReplaceFileName(value);
            }
        }
        public byte[] Raw { get; set; }

        public override string ToString()
        {
            return $"PackedContainer(\"{Name}\", len:{Raw.Length})";
        }
    }
}
