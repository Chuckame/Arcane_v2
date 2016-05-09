using Chuckame.IO.TCP.Messages;
using Arcane.Login.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcane.Protocol;
using Arcane.Protocol.Messages;
using Arcane.Base.Tools;
using Arcane.Base.Encryption;

namespace Arcane.Login.Frames
{
    public class ConnectionFrame : AbstractFrame<ConnectionFrame, LoginClient, AbstractMessage>
    {
        public string Salt = Utils.RandomString(32);
        public ConnectionFrame(LoginClient client) : base(client)
        {
        }

        public override void OnAttached()
        {
            Client.SendMessage(new ProtocolRequired(1444, 1444));
            Client.SendMessage(new HelloConnectMessage(Salt, RSAProtocol.PublicKey));
        }

        public override void OnDettached()
        {
        }

        //[MessageHandler]
        //public void test(MessageTest msg)
        //{
        //    Console.WriteLine($"ConnectionFrame: new MessageTest(Value:{msg.Value})");
        //}
    }
}
