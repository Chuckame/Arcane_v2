using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dofus.Files.Common;
using Dofus.Files.Elements;
using Dofus.Files.Localization;
using Dofus.Files.Packed;

namespace Dofus.Files.Utils
{
    public static class DofusFilesUtils
    {
        public static ILocalizationFile CreateI18nFileReader()
        {
            ILocalizationFile instance = VerifAndCreateInstanceOf<LocalizationFile2>();
            if (instance == null)
                instance = VerifAndCreateInstanceOf<LocalizationFile>();
            return instance;
        }
        public static IPackedFile CreatePakedFile()
        {
            return VerifAndCreateInstanceOf<PackedFile>();
        }
        public static IElementsFile CreateElementsFile()
        {
            return VerifAndCreateInstanceOf<ElementsFile>();
        }
        private static T VerifAndCreateInstanceOf<T>() where T : new()
        {
            if (DofusConfig.Instance.GetDofusVersion() >= DofusMinVersionUtils.GetVersionOf<T>())
                return new T();
            return default(T);
        }
    }
}
