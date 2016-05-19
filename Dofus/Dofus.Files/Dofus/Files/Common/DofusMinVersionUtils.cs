using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dofus.Files.Common
{
    internal static class DofusMinVersionUtils
    {
        private static readonly Version DEFAULT_VERSION = new Version(2, 0);
        public static Version GetVersionOf<T>()
        {
            Version version;
            var attrs = typeof(T).GetCustomAttributes(typeof(DofusMinVersion), false);

            if (attrs.Length > 0)
                version = (attrs[0] as DofusMinVersion).MinVersion;
            else
                version = (Version)DEFAULT_VERSION.Clone();
            return version;
        }
    }
}
