using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dofus.Files.Packed
{
    public static class PackedContainerHelper
    {
        public static bool IsValidFileName(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentNullException(nameof(fileName));
            fileName = fileName.Trim();
            return fileName[0] != '/' && fileName[0] != '\\' && fileName[0] != '|';
        }

        public static string ReplaceFileName(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentNullException(nameof(fileName));
            if (!IsValidFileName(fileName))
                throw new ArgumentException($"{nameof(fileName)}: invalid file name.");
            return fileName.Trim().Replace('\\', '/');
        }
    }
}
