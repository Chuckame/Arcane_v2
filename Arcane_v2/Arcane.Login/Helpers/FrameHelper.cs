using Arcane.Login.Frames;
using Arcane.Login.Network;
using Arcane.Protocol.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Login.Helpers
{
    public static class FrameHelper
    {
        public static void GoToNicknameRegistration(LoginClient client)
        {
            client.AddFrame(new NicknameRegistrationFrame(client));
        }
        public static void GoToServerSelection(LoginClient client)
        {
            client.AddFrame(new ServerSelectionFrame(client));
        }
        public static void AutoSelectServer(LoginClient client, short serverId)
        {
            var frame = new ServerSelectionFrame(client);
            client.AddFrame(frame);
            frame.ServerSelectionMessage(new ServerSelectionMessage(serverId));
        }
    }
}
