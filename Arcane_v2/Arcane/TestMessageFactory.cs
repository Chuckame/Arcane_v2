using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Arcane.IO.TCP.Messages;

namespace Arcane
{
    class TestMessageFactory : IMessageFactory
    {
        public IEnumerable<IMessage> buildMessages(byte[] raw)
        {
            return new Collection<IMessage>() { new Base.Network.Messages.RawMessage { Bytes = raw } };
        }
    }
}
