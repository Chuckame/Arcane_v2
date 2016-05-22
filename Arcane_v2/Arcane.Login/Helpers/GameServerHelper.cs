using Arcane.Base.Entities;
using Arcane.Login.Network.GameLink;
using Arcane.Protocol.Enums;
using Arcane.Protocol.Messages;
using Arcane.Protocol.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Login.Helpers
{
    public static class GameServerHelper
    {
        public static ServersListMessage MakeServersListMessage(Account account)
        {
            var servers = new List<GameServerInformations>();
            foreach (var server in GameServerEntity.FindAll())
            {
                servers.Add(MakeGameServerInformations(account, server));
            }
            return new ServersListMessage(servers.ToArray());
        }
        public static GameServerInformations MakeGameServerInformations(Account account, GameServerEntity server)
        {
            return new GameServerInformations(server.Id, server.Status.ToSByte(), server.Completion, server.Status.IsSelectable(), GetCharactersCount(account, server.Id), server.CreationDate.ToDofusTimestamp());
        }
        public static sbyte GetCharactersCount(Account account, ushort serverId)
        {
            if (GameLinkManager.Instance.IsServerExists(serverId))
                return GameLinkManager.Instance.GetClientCharactersCount(account, serverId);
            return 0;
        }
        public static bool IsSelectable(this ServerStatusEnum status)
        {
            switch (status)
            {
                case ServerStatusEnum.ONLINE:
                    return true;
                case ServerStatusEnum.STATUS_UNKNOWN:
                case ServerStatusEnum.OFFLINE:
                case ServerStatusEnum.STARTING:
                case ServerStatusEnum.NOJOIN:
                case ServerStatusEnum.SAVING:
                case ServerStatusEnum.STOPING:
                case ServerStatusEnum.FULL:
                default:
                    return false;
            }
        }
    }
}
