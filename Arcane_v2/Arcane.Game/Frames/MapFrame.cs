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
using static Arcane.Game.Network.GameLink.TicketManager;
using Arcane.Protocol.Enums;

namespace Arcane.Game.Frames
{
    public class MapFrame : AbstractFrame<MapFrame, GameClient, AbstractMessage>
    {
        private static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();
        public MapFrame(GameClient client) : base(client)
        {
        }

        protected override void OnAttached()
        {
            Client.DispatchMessage(new ChangeMapMessage(0));
        }

        protected override void OnDetached()
        {
        }

        [MessageHandler]
        public void MapInformationsRequestMessage(MapInformationsRequestMessage msg)
        {
            Client.SendMessage(new MapComplementaryInformationsDataMessage(1, msg.mapId, 0, new HouseInformations[0], new GameRolePlayActorInformations[] { Client.Character.ToGameRolePlayActorInformations() }, new InteractiveElement[0], new StatedElement[0], new MapObstacle[0], new FightCommonInformations[0]));
        }

        [MessageHandler]
        public void ChangeMapMessage(ChangeMapMessage msg)
        {
            Client.SendMessage(new CurrentMapMessage(msg.mapId, Config.MapKey));
        }
    }
}
