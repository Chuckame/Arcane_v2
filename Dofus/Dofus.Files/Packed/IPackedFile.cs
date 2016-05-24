using System.Collections.Generic;
using System.IO;
using Dofus.IO;

namespace Dofus.Files.Packed
{
    public interface IPackedFile : IDofusFile
    {
        IReadOnlyDictionary<string, byte[]> Files { get; }
        byte[] this[string fileName] { get; set; }
        string LinkedFileName { get; set; }
        void AddFile(string fileName, byte[] data);
        void AddFile(string fileName, string srcFilePath);
        void AddFile(string fileName, Stream stream);
        void AddFile(string fileName, IDataReader reader);
        void SetFile(string fileName, byte[] data);
        byte[] GetFile(string fileName);
        bool Remove(string fileName);
        bool Contains(string fileName);
    }
}