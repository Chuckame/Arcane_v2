using Arcane.Game.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Game.Frames
{
    public static class FrameFactory
    {
        public static ApproachFrame CreateApproachFrame(GameClient client)
        {
            return new ApproachFrame(client);
        }
        public static CharacterChoiceFrame CreateCharacterChoiceFrame(GameClient client)
        {
            var mainFrame = new CharacterChoiceFrame(client);
            mainFrame.AddDependencies(CreateCharacterCreationFrame(client));
            if (client.Account.IsAdmin)
                mainFrame.AddDependencies(CreateCharacterChoiceAdminPanelFrame(client));
            return mainFrame;
        }
        public static CharacterCreationFrame CreateCharacterCreationFrame(GameClient client)
        {
            return new CharacterCreationFrame(client);
        }
        public static CharacterChoiceAdminPanelFrame CreateCharacterChoiceAdminPanelFrame(GameClient client)
        {
            return new CharacterChoiceAdminPanelFrame(client);
        }
        public static SocialFrame SocialFrame(GameClient client)
        {
            return new SocialFrame(client);
        }
        public static QuestFrame QuestFrame(GameClient client)
        {
            return new QuestFrame(client);
        }
        public static ContextFrame ContextFrame(GameClient client)
        {
            return new ContextFrame(client);
        }
    }
}
