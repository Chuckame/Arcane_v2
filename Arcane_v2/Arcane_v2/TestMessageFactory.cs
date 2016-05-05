using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcane.Base.Network;
using System.Collections.ObjectModel;

namespace Arcane
{
    class TestMessageFactory : Base.Network.IMessageFactory
    {
        public IEnumerable<IMessage> buildMessages(byte[] raw)
        {
            return new Collection<IMessage>() { new Base.Network.Messages.RawMessage { Bytes = raw } };
        }
    }
}
