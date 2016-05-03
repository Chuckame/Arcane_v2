using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Base.Network
{
    public interface IMessage
    {
        byte[] Serialize();
        void Deserialize(byte[] raw);
    }
}
