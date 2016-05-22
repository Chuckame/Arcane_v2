using Arcane.Base.Common;
using Arcane.Base.Entities;
using Arcane.Base.Tools;
using Arcane.Game.Entities;
using Arcane.Game.Network.GameLink;
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
using Arcane.Game.Helpers;
using Arcane.Game.Wrappers;
using Arcane.Protocol.Types;
using Arcane.Game.Network;
using static Arcane.Game.Network.GameLink.TicketManager;
using Arcane.Protocol.Enums;

namespace Arcane.Game.Frames
{
    public class CharacterChoiceAdminPanelFrame : AbstractFrame<CharacterChoiceAdminPanelFrame, GameClient, AbstractMessage>
    {
        private static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();
        public CharacterChoiceAdminPanelFrame(GameClient client) : base(client)
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
                    Client.SendMessage(new ConsoleMessage(ConsoleMessageTypeEnum.CONSOLE_INFO_MESSAGE.ToSByte(), $"Available commands:\n- <b>refresh</b>: Refresh characters list."));
                    break;
                case "refresh":
                    Client.DispatchMessage(new CharactersListRequestMessage());
                    break;
                default:
                    Client.SendMessage(new ConsoleMessage(ConsoleMessageTypeEnum.CONSOLE_ERR_MESSAGE.ToSByte(), $"Unknown '{cmd}' command. Try 'help'."));
                    break;
            }
        }
    }
}
