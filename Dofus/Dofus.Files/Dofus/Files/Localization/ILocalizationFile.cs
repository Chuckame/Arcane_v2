using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dofus.IO;

namespace Dofus.Files.Localization
{
    public interface ILocalizationFile : IDofusFile
    {
        IReadOnlyDictionary<int, string> IndexedTexts { get; }
        IReadOnlyDictionary<string, string> NamedTexts { get; }
        int GetNextId();
        string this[int id] { get; set; }
        string this[string uiName] { get; set; }
        bool Contains(int id);
        bool Contains(string uiName);
        void Add(int id, string value);
        void Add(string uiName, string value);
    }
}
