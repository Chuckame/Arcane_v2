﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dofus.Files.Common;
using Dofus.Files.Elements;
using Dofus.Files.Localization;
using Dofus.Files.Packed;
using Dofus.Files.Dofus.Files.Maps;

namespace Dofus.Files.Common
{
    public static class DofusFilesUtils
    {
        public static ILocalizationFile CreateLocalizationFile()
        {
            return new LocalizationFile();
        }
        public static IPackedFile CreatePakedFile()
        {
            return new PackedFile();
        }
        public static IElementsFile CreateElementsFile()
        {
            return new ElementsFile();
        }
        public static IMapFile CreateMapFile()
        {
            return new MapFile();
        }
    }
}
