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
using Dofus.Files.GameData;
using Arcane.Protocol.Datacenter;
using Arcane.Protocol.Types;
using Arcane.Game.Helpers;

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
                var breed = CharacterHelper.GetTemplateBreed((PlayableBreedEnum)msg.breed);
                if (breed == null)
                {
                    throw new NullReferenceException($"Unable to find breed id#{msg.breed}.");
                }
                else
                {
                    var templateLook = (msg.sex ? breed.femaleLook : breed.maleLook).ToEntityLook();
                    var createdCharacter = new CharacterEntity
                    {
                        Breed = (PlayableBreedEnum)msg.breed,
                        Colors = FinalizeColors(breed, msg.sex, msg.colors),
                        Name = msg.name,
                        Sex = msg.sex ? SexEnum.Female : SexEnum.Male,
                        Owner = Client.Account,
                        Scale = templateLook.scales[0],
                        BonesId = (short)breed.creatureBonesId,
                        LastSelection = DateTime.Now
                    };
                    createdCharacter.Create();
                    Client.SendMessage(new CharacterCreationResultMessage(CharacterCreationResultEnum.OK.ToSByte()));
                    Client.DispatchMessage(new CharactersListRequestMessage());
                }
            }
            catch (Exception e)
            {
                Client.SendMessage(new CharacterCreationResultMessage(CharacterCreationResultEnum.ERR_NO_REASON.ToSByte()));
                LOGGER.Error(e);
            }
        }

        private int[] FinalizeColors(Breed breed, bool sex, int[] receivedColors)
        {
            var templateColors = (sex ? breed.femaleColors : breed.maleColors).Select(x => (int)x).ToArray();
            var finalColors = receivedColors.Take(templateColors.Length).ToArray();
            for (int i = 0; i < finalColors.Length; i++)
            {
                if (finalColors[i] == -1)
                {
                    finalColors[i] = templateColors[i];
                }
                else
                {
                    finalColors[i] = finalColors[i] & 16777215;
                }
            }
            return finalColors;
        }
    }
}
