using Arcane.Base.Network;
using Arcane.Base.Network.Messages;
using Arcane.Login.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Login.Frames
{
    class ConnectionFrame : AbstractFrame<LoginClient>
    {
        public ConnectionFrame(LoginClient client) : base(client)
        {
        }

        public override bool Dispatch(IMessage message)
        {
            if (message is MessageTest)
            {
                test(message as MessageTest);
                return true;
            }
            return false;
        }

        [MessageHandler]
        void test(MessageTest msg)
        {
        }
    }
}
