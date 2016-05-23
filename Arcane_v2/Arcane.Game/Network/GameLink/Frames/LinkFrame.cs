using Arcane.Base.Entities;
using Arcane.Base.Network.GameLink.Messages;
using Arcane.Game.Entities;
using Arcane.Game.Helpers;
using Castle.ActiveRecord;
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

        protected override void OnAttached()
        {
            Client.SendMessage(new StatusMessage { Status = GameLinkConnectorManager.Instance.ServerStatus });
        }

        protected override void OnDetached()
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

        [MessageHandler]
        public void RequestCharactersCountMessage(RequestCharactersCountMessage msg)
        {
            var account = Account.TryFind(msg.AccountId);
            if (account != null)
            {
                using (new SessionScope())
                {
                    Client.SendMessage(new CharactersCountMessage { AccountId = msg.AccountId, CharactersCount = (sbyte)CharacterEntity.Queryable.Count(c => c.Owner.Id == msg.AccountId), Token = msg.Token });
                }
            }
            else
            {
                Client.SendMessage(new CharactersCountMessage { AccountId = msg.AccountId, CharactersCount = 0, Token = msg.Token });
            }
        }

        [MessageHandler]
        public void SearchPseudoMessage(SearchCharacterOwnerMessage msg)
        {
            if (CharacterHelper.IsCharacterOwnerNicknameExists(msg.Pseudo))
            {
                Client.SendMessage(new SearchCharacterOwnerResultMessage { Success = true, Token = msg.Token });
            }
            else
            {
                Client.SendMessage(new SearchCharacterOwnerResultMessage { Success = false, Token = msg.Token });
            }
        }

        [MessageHandler]
        public void SearchPseudoMessage(RequestClientDisconnectionMessage msg)
        {
            if (Account.Exists(msg.AccountId))
            {
                GameServerManager.Instance.DisconnectClientByAccount(Account.Find(msg.AccountId));
            }
        }

        [MessageHandler]
        public void SearchPseudoMessage(TestMessage msg)
        {
            Client.SendMessage(new TestResponseMessage{ TestStr="LAWL" });
        }
    }
}
