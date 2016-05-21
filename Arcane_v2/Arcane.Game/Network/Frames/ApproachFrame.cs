using Arcane.Base.Common;
using Arcane.Base.Entities;
using Arcane.Base.Tools;
using Arcane.Game.Network.GameLink;
using Arcane.Protocol;
using Arcane.Protocol.Messages;
using Chuckame.IO.TCP.Messages;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Arcane.Game.Network.GameLink.TicketManager;

namespace Arcane.Game.Network.Frames
{
    public class ApproachFrame : AbstractFrame<ApproachFrame, GameClient, AbstractMessage>
    {
        private static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();
        public ApproachFrame(GameClient client) : base(client)
        {
        }

        public override void OnAttached()
        {
            Client.SendMessage(new ProtocolRequired(CommonConfig.ProtocolRequiredVersion, CommonConfig.ProtocolCurrentVersion));
            Client.SendMessage(new HelloGameMessage());
        }

        public override void OnDettached()
        {
        }

        [MessageHandler]
        public void AuthenticationTicketMessage(AuthenticationTicketMessage msg)
        {
            try
            {
                var ticket = GameLinkConnectorManager.Instance.TicketManager.UseTicket(msg.ticket);
                if (Account.Exists(ticket.AccountId))
                {
                    Client.Account = Account.Find(ticket.AccountId);
                    Client.SendMessage(new BasicTimeMessage(Utils.GetIntTimestamp(), 7200));
                    Client.SendMessage(new ServerOptionalFeaturesMessage(new short[] { 1, 2, 3, 4, 5, 6 }));
                    Client.SendMessage(new AuthenticationTicketAcceptedMessage());
                    Client.SendMessage(new AccountCapabilitiesMessage(Client.Account.Id, Config.CharacterCreation_TutorialAvailable, Config.CharacterCreation_BreedsVisible, Config.CharacterCreation_BreedsAvailable, 0/*admin status*/));
                }
            }
            catch (TicketException e)
            {
                LOGGER.Error(e);
                Client.SendMessage(new AuthenticationTicketRefusedMessage());
            }

        }

        [MessageHandler]
        public void ClientKeyMessage(ClientKeyMessage msg)
        {
            Client.ClientKey = msg.key;
        }

        [MessageHandler]
        public void CharactersListRequestMessage(CharactersListRequestMessage msg)
        {
            Client.SendMessage(new CharactersListMessage(false, new Protocol.Types.CharacterBaseInformations[0]));
        }
    }
}
