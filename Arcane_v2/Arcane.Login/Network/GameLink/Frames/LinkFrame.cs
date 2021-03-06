﻿using Arcane.Base.Entities;
using Arcane.Base.Network.GameLink.Messages;
using Castle.ActiveRecord;
using Chuckame.IO.TCP.Messages;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Login.Network.GameLink.Frames
{
    public class LinkFrame : AbstractFrame<LinkFrame, GameLinkClient, AbstractGameLinkMessage>
    {
        private static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();

        public LinkFrame(GameLinkClient client) : base(client)
        {
        }

        protected override void OnAttached()
        {
            Client.SendMessage(new GameServerAcceptedMessage());
            //var result = Client.SendMessageAndWaitResponse<TestResponseMessage>(new TestMessage { TestStr = "LAWL" }, (m) => m.TestStr.Equals("LAWL"));
        }

        protected override void OnDetached()
        {
        }

        [MessageHandler]
        public void StatusMessage(StatusMessage msg)
        {
            Client.UpdateStatus(msg.Status);
        }

        [MessageHandler]
        public void ClientConnectedMessage(ClientConnectedMessage msg)
        {
            var account = Account.TryFind(msg.AccountId);
            if (account == null)
            {
                LOGGER.Info("Unknown account has request connection, going to disconnect this fucking shit.");
                Client.SendMessage(new RequestClientDisconnectionMessage { AccountId = msg.AccountId });
            }
            else
            {
                Client.AddAccount(account);
            }
        }

        [MessageHandler]
        public void ClientDisconnectedMessage(ClientDisconnectedMessage msg)
        {
            var account = Account.TryFind(msg.AccountId);
            if (account == null)
            {
                LOGGER.Info("Unknown account ! Aleert !");
            }
            else
            {
                Client.RemoveAccount(account);
            }
        }
    }
}
