using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Base.Network.Messages
{
    internal class EmptyMessage : IMessage
    {
        private static EmptyMessage _mInstance = new EmptyMessage();

        public static EmptyMessage Instance
        {
            get
            {
                return _mInstance;
            }
        }

        private EmptyMessage()
        {

        }

        public void Deserialize(byte[] raw)
        {
            throw new NotImplementedException();
        }

        public byte[] Serialize()
        {
            throw new NotImplementedException();
        }
    }
}
