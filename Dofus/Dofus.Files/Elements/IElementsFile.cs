using Dofus.Files.Elements.ElementTypes;
using Dofus.IO;
using System.Collections.Generic;

namespace Dofus.Files.Elements
{
    public interface IElementsFile : ICollection<GraphicalElementData>, IDofusFile
    {
        GraphicalElementData this[int elementId] { get; }

        byte FileVersion { get; set; }

        bool ElementExists(int elementId);
        GraphicalElementData GetElementData(int elementId);
        bool IsJpg(int gfxId);
        void SetIsJpg(int gfxId, bool isJpg = true);
    }
}