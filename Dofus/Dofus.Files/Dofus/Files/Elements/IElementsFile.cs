using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dofus.IO;

namespace Dofus.Files.Elements
{
    public interface IElementsFile : IDofusFile
    {
        byte FileVersion { get; }
        bool Parsed { get; }
        GraphicalElementData this[int elementId] { get; }
        int GetNextElementId();
        GraphicalElementData GetElementData(int elementId);
        IList<GraphicalElementData> GetElementsList();
        IDictionary<int, GraphicalElementData> GetElements();
        bool IsJpg(int gfxId);
        void Add(GraphicalElementData element);
        int Count();
        bool Contains(int elementId);
    }
}
