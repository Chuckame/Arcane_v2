using Arcane.Base.Entities;
using Arcane.Game.Network;
using Arcane.Game.Wrappers;
using Arcane.Protocol.Enums;
using Arcane.Protocol.Messages;
using Arcane.Protocol.Types;
using Castle.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Game.Helpers
{
    public static class SocialHelper
    {
        public static FriendsListMessage MakeIgnoredList(this CharacterWrapper account)
        {
            var msg = new FriendsListMessage(new FriendInformations[0]);
            return msg;
        }
        public static FriendsListMessage MakeFriendsList(this Account account)
        {
            using (new SessionScope())
            {
                return new FriendsListMessage(new FriendInformations[0]);
                var msg = new FriendsListMessage(new FriendInformations[account.Friends.Count]);
                int i = 0;
                foreach (var friend in account.Friends)
                {
                    msg.friendsList[i++] = friend.ToFriendInformations();
                }
                return msg;
            }
        }
        public static FriendInformations ToFriendInformations(this Account account)
        {
            if (GameServerManager.Instance.IsAccountConnected(account))
            {
                var client = GameServerManager.Instance.GetClientByAccount(account);
                if (client.HasCharacter)
                {
                    var character = client.Character;
                    PlayerStateEnum state;
                    switch (client.Character.CurrentContext)
                    {
                        case GameContextEnum.ROLE_PLAY:
                            state = PlayerStateEnum.GAME_TYPE_ROLEPLAY;
                            break;
                        case GameContextEnum.FIGHT:
                            state = PlayerStateEnum.GAME_TYPE_FIGHT;
                            break;
                        default:
                            state = PlayerStateEnum.UNKNOWN_STATE;
                            break;
                    }
                    sbyte moodSmileyId = 0;
                    BasicGuildInformations guildInfo = new BasicGuildInformations(1, "L'enfer");
                    return new FriendOnlineInformations(account.Id, account.Nickname, state.ToSByte(), (int)new TimeSpan(account.LastConnectionDate.Value.Ticks).TotalHours, character.Character.Name, character.GetLevel(), AlignmentSideEnum.ALIGNMENT_WITHOUT.ToSByte(), character.Character.Breed.ToSByte(), character.Character.Sex.ToBoolean(), guildInfo, moodSmileyId);
                }
            }
            return new FriendInformations(account.Id, account.Nickname, PlayerStateEnum.NOT_CONNECTED.ToSByte(), (int)new TimeSpan(account.LastConnectionDate.Value.Ticks).TotalHours);
        }
    }
}
