using Arcane.Base.Entities;
using Arcane.Base.Network.GameLink.Messages;
using Chuckame.IO.TCP.Messages;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Game.Network.GameLink.Frames
{
    public class LinkFrame : AbstractFrame<LinkFrame, GameLinkConnector, AbstractGameLinkMessage>
    {
        private static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();

        public LinkFrame(GameLinkConnector client) : base(client)
        {
        }

        public override void OnAttached()
        {
            Client.SendMessage(new StatusMessage { Status = GameLinkConnectorManager.Instance.ServerStatus });
        }

        public override void OnDettached()
        {
        }

        [MessageHandler]
        public void ClientIncomingTokenMessage(ClientIncomingTokenMessage msg)
        {
            var account = Account.TryFind(msg.AccountId);
            if (account != null)
            {
                GameLinkConnectorManager.Instance.TicketManager.AddTicket(new TicketEntity(msg.AccountId, msg.Ticket));
                Client.SendMessage(new ClientIncomingTokenResultMessage { AccountId = msg.AccountId, Success = true, Token = msg.Token });
            }
            else
            {
                Client.SendMessage(new ClientIncomingTokenResultMessage { AccountId = msg.AccountId, Success = false, Token = msg.Token });
            }
        }
    }
}
