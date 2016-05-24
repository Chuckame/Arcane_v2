using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dofus.Files.Dofus.Files.Maps.Types
{
    [Flags]
    public enum MapChangeDataEnum
    {
        Right = 1,
        Bottom = 4,
        Left = 16,
        Top = 64
    }
}
