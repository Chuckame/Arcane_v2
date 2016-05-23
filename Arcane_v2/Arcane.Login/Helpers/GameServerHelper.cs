using Arcane.Base.Entities;
using Arcane.Base.Network.GameLink.Messages;
using Arcane.Login.Network.GameLink;
using Arcane.Protocol.Enums;
using Arcane.Protocol.Messages;
using Arcane.Protocol.Types;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Arcane.Base.Network.GameLink.LinkMessageHandle;

namespace Arcane.Login.Helpers
{
    public static class GameServerHelper
    {
        private static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();

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
            {
                var server = GameLinkManager.Instance.GetServer(serverId);
                try
                {
                    var result = server.SendMessageAndWaitResponse<CharactersCountMessage>(new RequestCharactersCountMessage { AccountId = account.Id }, 1000);
                    if (result.AccountId == account.Id)
                        return result.CharactersCount;
                    LOGGER.Error($"Result of 'RequestCharactersCountMessage' for '{account}' was not corresponding to requested account id.");
                }
                catch (HandleTimeoutException)
                {
                    LOGGER.Error($"Result of 'RequestCharactersCountMessage' time out.");
                }
            }
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
