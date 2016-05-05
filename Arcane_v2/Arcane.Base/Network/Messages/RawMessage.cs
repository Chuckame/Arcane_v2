using Arcane.IO.TCP.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Base.Network.Messages
{
    public class RawMessage : IMessage
    {
        public byte[] Bytes { get; set; }

        public void Deserialize(byte[] raw)
        {
            Bytes = new byte[raw.Length];
            raw.CopyTo(Bytes, 0);
        }

        public byte[] Serialize()
        {
            var result = new byte[Bytes.Length];
            Bytes.CopyTo(result, 0);
            return result;
        }
    }
}
