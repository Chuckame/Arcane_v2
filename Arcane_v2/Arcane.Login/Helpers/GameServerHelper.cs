using Arcane.Base.Entities;
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
                sbyte charactersCount = 1;
                servers.Add( new GameServerInformations(server.Id, server.Status.ToSByte(), server.Completion, server.Status.IsSelectable(), charactersCount, server.CreationDate.ToDofusTimestamp()));
            }
            return new ServersListMessage(servers.ToArray());
        }
        private static bool IsSelectable(this ServerStatusEnum status)
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
