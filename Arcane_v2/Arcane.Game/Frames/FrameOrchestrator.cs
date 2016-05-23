using Arcane.Game.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Game.Frames
{
    public static class FrameOrchestrator
    {
        public static void GoToApproach(GameClient client)
        {
            client.AddFrame(FrameFactory.CreateApproachFrame(client));
        }
        public static void GoToCharacterChoice(GameClient client)
        {
            client.AddFrame(FrameFactory.CreateCharacterChoiceFrame(client));
        }
        public static void GoToGame(GameClient client)
        {
            client.AddFrame(FrameFactory.ContextFrame(client));
            client.AddFrame(FrameFactory.QuestFrame(client));
            client.AddFrame(FrameFactory.SocialFrame(client));
        }
    }
}
