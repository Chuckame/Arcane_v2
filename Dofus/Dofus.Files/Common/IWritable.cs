using Dofus.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dofus.Files.Dofus.Files.Common
{
    public interface IWritable
    {
        void WriteTo(IDataWriter writer);
    }
}
