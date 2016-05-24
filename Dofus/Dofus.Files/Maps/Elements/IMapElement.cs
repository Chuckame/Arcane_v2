using Dofus.Files.Dofus.Files.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dofus.Files.Dofus.Files.Maps.Types;

namespace Dofus.Files.Dofus.Files.Maps.Elements
{
    public interface IMapElement : IReadable, IWritable
    {
        ElementTypesEnum ElementType { get; }
    }
}
