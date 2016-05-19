using Dofus.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Protocol
{
    public abstract class AbstractType
    {
        public abstract short TypeId { get; }

        public abstract void Deserialize(IDataReader reader);
        public abstract void Serialize(IDataWriter writer);
    }
}