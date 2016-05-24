using Dofus.IO;
using System.Collections.Generic;

namespace Dofus.Files.Packed
{
    public interface IPackedFile : IDofusFile, ICollection<PackedContainer>
    {
        PackedContainer this[string fileName] { get; set; }

        string LinkedFileName { get; set; }

        bool Contains(string fileName);
    }
}