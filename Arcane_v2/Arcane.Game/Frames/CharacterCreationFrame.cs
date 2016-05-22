using Arcane.Base.Common;
using Arcane.Base.Entities;
using Arcane.Base.Tools;
using Arcane.Game.Network;
using Arcane.Game.Network.GameLink;
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
using static Arcane.Game.Network.GameLink.TicketManager;
using Arcane.Game.Entities;

namespace Arcane.Game.Frames
{
    public class CharacterCreationFrame : AbstractFrame<CharacterCreationFrame, GameClient, AbstractMessage>
    {
        private static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();
        public CharacterCreationFrame(GameClient client) : base(client)
        {
        }

        protected override void OnAttached()
        {
        }

        protected override void OnDetached()
        {
        }

        [MessageHandler]
        public void CharacterNameSuggestionRequestMessage(CharacterNameSuggestionRequestMessage msg)
        {
            Client.SendMessage(new CharacterNameSuggestionSuccessMessage(Utils.RandomString(10)));
        }

        [MessageHandler]
        public void CharacterCreationRequestMessage(CharacterCreationRequestMessage msg)
        {
            try
            {
                var createdCharacter = new CharacterEntity
                {
                    Breed = (PlayableBreedEnum)msg.breed,
                    Colors = msg.colors.Take(5).ToArray(),
                    Name = msg.name,
                    Sex = msg.sex ? SexEnum.Female : SexEnum.Male,
                    Owner = Client.Account,
                    Scale = 140,
                    BonesId = 38,
                    LastSelection = DateTime.Now
                };
                createdCharacter.Create();
                Client.SendMessage(new CharacterCreationResultMessage(CharacterCreationResultEnum.OK.ToSByte()));
                Client.DispatchMessage(new CharactersListRequestMessage());
            }
            catch (Exception e)
            {
                Client.SendMessage(new CharacterCreationResultMessage(CharacterCreationResultEnum.ERR_NO_REASON.ToSByte()));
                LOGGER.Error(e);
            }
        }
    }
}
