using Arcane.Base.Network.GameLink.Messages;
using Chuckame.IO.TCP.Messages;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Login.Network.GameLink.Frames
{
    public class GameLinkFrame : AbstractFrame<GameLinkFrame, GameLinkClient, IGameLinkMessage>
    {
        private static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();

        public GameLinkFrame(GameLinkClient client) : base(client)
        {
        }

        public override void OnAttached()
        {
        }

        public override void OnDettached()
        {
        }
    }
}
