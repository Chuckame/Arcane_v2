using Arcane.Base.Common;
using Arcane.Base.Entities;
using Arcane.Base.Tools;
using Arcane.Game.Entities;
using Arcane.Game.Network.GameLink;
using Arcane.Protocol;
using Arcane.Protocol.Messages;
using Castle.ActiveRecord;
using Chuckame.IO.TCP.Messages;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcane.Game.Helpers;
using Arcane.Game.Wrappers;
using Arcane.Protocol.Types;
using Arcane.Game.Network;

namespace Arcane.Game.Frames
{
    public class CharacterChoiceFrame : AbstractFrame<CharacterChoiceFrame, GameClient, AbstractMessage>
    {
        private static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();
        private LinkedList<CharacterWrapper> CharacterWrappers;
        public CharacterChoiceFrame(GameClient client) : base(client)
        {
        }

        protected override void OnAttached()
        {
        }

        protected override void OnDetached()
        {
        }

        [MessageHandler]
        public void CharactersListRequestMessage(CharactersListRequestMessage msg)
        {
            CharacterWrappers = CharacterHelper.GetCharacters(Client.Account.Id);
            var hasStartupActions = false;
            Client.SendMessage(new CharactersListMessage(hasStartupActions, CharacterWrappers.Select(c => c.ToCharacterBaseInformations()).ToArray()));
        }

        [MessageHandler]
        public void CharacterSelectionMessage(CharacterSelectionMessage msg)
        {
            if (CharacterWrappers == null)
            {
                Client.SendMessage(new CharacterSelectedErrorMessage());
            }
            else if (CharacterWrappers.Any(c => c.Character.Id == msg.id))
            {
                var selectedCharacter = CharacterWrappers.First(c => c.Character.Id == msg.id);
                selectedCharacter.Character.UpdateLastSelection(DateTime.Now);
                Client.Character = selectedCharacter;
                Client.SendMessage(new CharacterSelectedSuccessMessage(Client.Character.ToCharacterBaseInformations()));
            }
            else
            {
                Client.SendMessage(new CharacterSelectedErrorMessage());
            }
        }
    }
}
