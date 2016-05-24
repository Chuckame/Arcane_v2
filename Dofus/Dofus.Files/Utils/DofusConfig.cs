using System;
using System.IO;
using System.Xml;
using Dofus.IO;
using Dofus.Files.Exceptions;
using System.Linq;

namespace Dofus.Files.Utils
{
    public class DofusConfig
    {

        private static DofusConfig _mInstance = new DofusConfig();
        private string _mAppDirectory;
        private Version dofusVersion;

        public static DofusConfig Instance
        {
            get { return _mInstance; }
        }
        public string AppDirectory
        {
            get
            {
                if (_mAppDirectory == null)
                    throw new ConfigException("'AppDirectory' property must be set before.");
                return _mAppDirectory;
            }
            set
            {
                _mAppDirectory = value;
                UpdateDofusVersion();
            }
        }
        public string GetCommonDirectory()
        {
            return Path.Combine(GetDataDirectory(), "common");
        }
        public string GetContentDirectory()
        {
            return Path.Combine(AppDirectory, "content");
        }

        public string GetDataDirectory()
        {
            return Path.Combine(AppDirectory, "data");
        }
        public Version GetDofusVersion()
        {
            return dofusVersion;
        }
        public string GetGameDataFilePath(string module)
        {
            return Path.Combine(GetCommonDirectory(), $"{module}.d2o");
        }
        public string GetI18NDirectory()
        {
            return Path.Combine(GetDataDirectory(), "i18n");
        }
        public string GetI18NFilePath(Language language)
        {
            string val;
            switch (language)
            {
                case Language.French:
                    val = "fr";
                    break;
                case Language.German:
                    val = "de";
                    break;
                case Language.Japanish:
                    val = "ja";
                    break;
                case Language.Dutsh:
                    val = "nl";
                    break;
                case Language.Portugese:
                    val = "pt";
                    break;
                case Language.Russian:
                    val = "ru";
                    break;
                case Language.Italian:
                    val = "it";
                    break;
                case Language.English:
                    val = "en";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(language), language, null);
            }
            return Path.Combine(GetI18NDirectory(), $"i18n_{val}.d2i");
        }
        public string GetMapsDirectory()
        {
            return Path.Combine(GetContentDirectory(), "maps");
        }
        public string GetUplauncherComponentsFilePath()
        {
            return Path.Combine(AppDirectory, "uplauncherComponents.xml");
        }
        private void UpdateDofusVersion()
        {
            if (File.Exists(GetUplauncherComponentsFilePath()))
            {
                var doc = new XmlDocument();
                doc.Load(GetUplauncherComponentsFilePath());
                XmlNode root = doc.DocumentElement;
                var sel = root.SelectSingleNode("component[@name='all']");
                var versionAttr = (XmlAttribute)sel.Attributes.GetNamedItem("version");
                var splittedVersion = versionAttr.Value.Split('.').Select(item => int.Parse(item)).ToArray();
                dofusVersion = new Version(splittedVersion[0], splittedVersion[1], splittedVersion[2], splittedVersion[3]);
            }
        }
    }
}
