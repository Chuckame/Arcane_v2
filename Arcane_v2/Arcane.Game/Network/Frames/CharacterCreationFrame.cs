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
    public class CharacterCreationFrame : AbstractFrame<CharacterCreationFrame, GameClient, AbstractMessage>
    {
        private static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();
        public CharacterCreationFrame(GameClient client) : base(client)
        {
        }

        public override void OnAttached()
        {
        }

        public override void OnDettached()
        {
        }

        [MessageHandler]
        public void CharacterNameSuggestionRequestMessage(CharacterNameSuggestionRequestMessage msg)
        {
        }
    }
}
