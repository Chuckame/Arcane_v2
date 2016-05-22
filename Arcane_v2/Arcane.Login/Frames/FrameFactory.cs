using Arcane.Login.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Login.Frames
{
    public static class FrameFactory
    {
        public static ServerSelectionFrame CreateServerSelectionFrame(LoginClient client)
        {
            var mainFrame = new ServerSelectionFrame(client);
            mainFrame.AddDependencies(CreatePseudoSearchFrame(client));
            if (client.Account.IsAdmin)
                mainFrame.AddDependencies(CreateServerSelectionAdminPanelFrame(client));
            return mainFrame;
        }
        public static ConnectionFrame CreateConnectionFrame(LoginClient client)
        {
            return new ConnectionFrame(client);
        }
        public static NicknameRegistrationFrame CreateNicknameRegistrationFrame(LoginClient client)
        {
            return new NicknameRegistrationFrame(client);
        }
        public static PseudoSearchFrame CreatePseudoSearchFrame(LoginClient client)
        {
            return new PseudoSearchFrame(client);
        }
        public static ServerSelectionAdminPanelFrame CreateServerSelectionAdminPanelFrame(LoginClient client)
        {
            return new ServerSelectionAdminPanelFrame(client);
        }
    }
}
