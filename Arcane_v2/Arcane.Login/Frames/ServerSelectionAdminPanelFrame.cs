using Arcane.Base.Common;
using Arcane.Base.Entities;
using Arcane.Base.Tools;
using Arcane.Login.Network.GameLink;
using Arcane.Protocol;
using Arcane.Protocol.Messages;
using Castle.ActiveRecord;
using Chuckame.IO.TCP.Messages;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcane.Login.Helpers;
using Arcane.Protocol.Types;
using Arcane.Login.Network;
using Arcane.Protocol.Enums;

namespace Arcane.Login.Frames
{
    public class ServerSelectionAdminPanelFrame : AbstractFrame<ServerSelectionAdminPanelFrame, LoginClient, AbstractMessage>
    {
        private static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();
        public ServerSelectionAdminPanelFrame(LoginClient client) : base(client)
        {
        }

        protected override void OnAttached()
        {
        }

        protected override void OnDetached()
        {
        }

        [MessageHandler]
        public void AdminCommandMessage(AdminCommandMessage msg)
        {
            var cmd = msg.content.Split(' ').FirstOrDefault();
            var parameters = msg.content.Split(' ').Skip(1).ToArray();
            switch (cmd)
            {
                case "help":
                    Client.SendMessage(new ConsoleMessage(ConsoleMessageTypeEnum.CONSOLE_INFO_MESSAGE.ToSByte(), $"Available commands:\n- <b>refresh</b>: Refresh servers list."));
                    break;
                case "refresh":
                    Client.SendMessage(GameServerHelper.MakeServersListMessage(Client.Account));
                    break;
                default:
                    Client.SendMessage(new ConsoleMessage(ConsoleMessageTypeEnum.CONSOLE_ERR_MESSAGE.ToSByte(), $"Unknown '{cmd}' command. Try 'help'."));
                    break;
            }
        }
    }
}
