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

namespace Arcane.Game.Frames
{
    public class ApproachFrame : AbstractFrame<ApproachFrame, GameClient, AbstractMessage>
    {
        private static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();
        public ApproachFrame(GameClient client) : base(client)
        {
        }

        protected override void OnAttached()
        {
            Client.SendMessage(new ProtocolRequired(CommonConfig.ProtocolRequiredVersion, CommonConfig.ProtocolCurrentVersion));
            Client.SendMessage(new HelloGameMessage());
        }

        protected override void OnDetached()
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
                    Client.SendMessage(new ServerOptionalFeaturesMessage(new short[] { 1, 2 }));
                    Client.SendMessage(new AuthenticationTicketAcceptedMessage());
                    Client.SendMessage(new AccountCapabilitiesMessage(Client.Account.Id, Config.CharacterCreation_TutorialAvailable, Config.CharacterCreation_BreedsVisible, Config.CharacterCreation_BreedsAvailable, 0/*admin status*/));
                    Client.RemoveFrame(this);
                    FrameOrchestrator.GoToCharacterChoice(Client);
                }
                else
                {
                    Client.SendMessage(new AuthenticationTicketRefusedMessage());
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
    }
}
