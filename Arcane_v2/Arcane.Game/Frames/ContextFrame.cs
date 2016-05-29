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
    public class ContextFrame : AbstractFrame<ContextFrame, GameClient, AbstractMessage>
    {
        private static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();
        public ContextFrame(GameClient client) : base(client)
        {
        }

        protected override void OnAttached()
        {
            Client.Character.CurrentContext = GameContextEnum.ROLE_PLAY;
        }

        protected override void OnDetached()
        {
        }

        [MessageHandler]
        public void GameContextCreateRequestMessage(GameContextCreateRequestMessage msg)
        {
            Client.SendMessage(new GameContextDestroyMessage());
            Client.SendMessage(new GameContextCreateMessage(Client.Character.CurrentContext.ToSByte()));
            Client.SendMessage(new TextInformationMessage(TextInformationTypeEnum.TEXT_INFORMATION_ERROR.ToSByte(), 89, new string[0]));
            Client.SendMessage(new TextInformationMessage(TextInformationTypeEnum.TEXT_INFORMATION_MESSAGE.ToSByte(), 152, new string[] { Client.Account.LastConnectionDate.Value.Year.ToString(), Client.Account.LastConnectionDate.Value.Month.ToString(), Client.Account.LastConnectionDate.Value.Day.ToString(), Client.Account.LastConnectionDate.Value.Hour.ToString(), Client.Account.LastConnectionDate.Value.Minute.ToString(), Client.Account.LastConnectionIp }));
            Client.AddFrame(new MapFrame(Client));
        }

        [MessageHandler]
        public void ClientKeyMessage(ClientKeyMessage msg)
        {
            Client.ClientKey = msg.key;
        }

        [MessageHandler]
        public void BasicPingMessage(BasicPingMessage msg)
        {
            Client.SendMessage(new BasicPongMessage(msg.quiet));
        }
    }
}
