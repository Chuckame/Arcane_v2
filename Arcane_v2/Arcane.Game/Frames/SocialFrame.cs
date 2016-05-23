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
    public class SocialFrame : AbstractFrame<SocialFrame, GameClient, AbstractMessage>
    {
        private static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();
        public SocialFrame(GameClient client) : base(client)
        {
            //TODO: FriendSetWarnOnConnectionMessage
            //TODO:  FriendDeleteRequestMessage
        }
        
        protected override void OnAttached()
        {
        }

        protected override void OnDetached()
        {
        }

        [MessageHandler]
        public void FriendsGetListMessage(FriendsGetListMessage msg)
        {
            Client.SendMessage(Client.Account.MakeFriendsList());
        }

        [MessageHandler]
        public void IgnoredGetListMessage(IgnoredGetListMessage msg)
        {
            Client.SendMessage(Client.Character.MakeIgnoredList());
        }

        [MessageHandler]
        public void FriendAddRequestMessage(FriendAddRequestMessage msg)
        {
            if (CharacterHelper.IsCharacterOwnerNicknameExists(msg.name))
            {
                var targetAccount = AccountHelper.GetAccountByNickname(msg.name);
                Client.Character.AddFriend(targetAccount);
                Client.SendMessage(new FriendAddedMessage(targetAccount.ToFriendInformations()));
            }
        }
    }
}
