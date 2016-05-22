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
            Client.SendMessage(new AcquaintanceSearchErrorMessage(AcquaintanceErrorEnum.NO_RESULT.ToSByte()));
        }
    }
}
