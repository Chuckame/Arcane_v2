using Arcane.Base.Network;
using Arcane.Login.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Login.Frames
{
    class ConnectionFrame : Frame<LoginClient, NetworkMessage>
    {
        ConnectionFrame()
        {
            RegisterMessageHandler((LoginClient c, TestM m) => test(c, m));
        }
        static void test(LoginClient client, TestM m)
        {
        }

        class TestM : NetworkMessage
        {
        }
    }
}
