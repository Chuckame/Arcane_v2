using Arcane.Login.Network;
using Arcane.Protocol;
using Arcane.Protocol.Messages;
using Arcane.Protocol.Enums;
using Chuckame.IO.TCP.Messages;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcane.Login.Network.GameLink;
using Arcane.Base.Network.GameLink.Messages;
using static Arcane.Base.Network.GameLink.LinkMessageHandle;

namespace Arcane.Login.Frames
{
    public class PseudoSearchFrame : AbstractFrame<PseudoSearchFrame, LoginClient, AbstractMessage>
    {
        private static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();

        public PseudoSearchFrame(LoginClient client) : base(client)
        {
        }

        protected override void OnAttached()
        {
        }

        protected override void OnDetached()
        {
        }

        [MessageHandler]
        public void AcquaintanceSearchMessage(AcquaintanceSearchMessage msg)
        {
            var foundServers = new LinkedList<short>();
            foreach (var server in GameLinkManager.Instance.GetValidServers())
            {
                SearchCharacterOwnerResultMessage result;
                try
                {
                    result = server.SendMessageAndWaitResponse<SearchCharacterOwnerResultMessage>(new SearchCharacterOwnerMessage { Pseudo = msg.nickname }, 1000);
                }
                catch (HandleTimeoutException)
                {
                    result = null;
                }
                if (result != null && result.Success)
                {
                    foundServers.AddLast((short)server.ServerInformations.Id);
                }
            }
            if (foundServers.Count > 0)
                Client.SendMessage(new AcquaintanceServerListMessage(foundServers.ToArray()));
            else
            {
                Client.SendMessage(new AcquaintanceSearchErrorMessage(AcquaintanceErrorEnum.NO_RESULT.ToSByte()));
                Client.SendMessage(new AcquaintanceServerListMessage(new short[0]));
            }
        }
    }
}
