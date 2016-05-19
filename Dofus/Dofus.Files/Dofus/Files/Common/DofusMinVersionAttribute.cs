using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dofus.Files.Common
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    sealed class DofusMinVersion : Attribute
    {
        readonly Version minVersion;

        public DofusMinVersion(string minVersion)
        {
            this.minVersion = Version.Parse(minVersion);
        }

        public Version MinVersion
        {
            get { return minVersion; }
        }
    }
}
