using Arcane.Login.Network;
using Arcane.Login.Network.GameLink;
using Arcane.Protocol.Enums;
using Arcane.Protocol.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Login.Frames
{
    public static class FrameOrchestrator
    {
        public static void GoToConnection(LoginClient client)
        {
            client.AddFrame(FrameFactory.CreateConnectionFrame(client));
        }
        public static void GoToNicknameRegistration(LoginClient client)
        {
            client.AddFrame(FrameFactory.CreateNicknameRegistrationFrame(client));
        }
        public static void GoToServerSelection(LoginClient client)
        {
            client.AddFrame(FrameFactory.CreateServerSelectionFrame(client));
        }
        public static void AutoSelectServer(LoginClient client, short serverId)
        {
            var status = GameLinkManager.Instance.GetLiveStatus((ushort)serverId);
            if (status == Protocol.Enums.ServerStatusEnum.ONLINE)
            {
                client.AddFrame(FrameFactory.CreateServerSelectionFrame(client));
                client.DispatchMessage(new ServerSelectionMessage(serverId));
            }
            else
            {
                client.SendMessage(new SelectedServerRefusedMessage(serverId, ServerConnectionErrorEnum.SERVER_CONNECTION_ERROR_DUE_TO_STATUS.ToSByte(), status.ToSByte()));
                client.Disconnect();
            }
        }
    }
}
