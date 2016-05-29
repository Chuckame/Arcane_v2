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
        private short? nextCellId;
        private DirectionsEnum? nextDirection;
        public MapFrame(GameClient client) : base(client)
        {
        }

        protected override void OnAttached()
        {
            Client.DispatchMessage(new ChangeMapMessage(Client.Character.MapId));
        }

        protected override void OnDetached()
        {
        }

        [MessageHandler]
        public void MapInformationsRequestMessage(MapInformationsRequestMessage msg)
        {
            if (msg.mapId != Client.Character.MapId)
            {
                LOGGER.Error($"{Client.Character} try to request map#{msg.mapId} but he is on map#{Client.Character.MapId}.");
            }
            else
            {
                Client.SendMessage(Client.Character.CurrentMap.ToMapComplementaryInformationsDataMessage());
                Client.Character.CurrentMap.NotifyMapInformationsSent(Client);
            }
        }

        [MessageHandler]
        public void ChangeMapMessage(ChangeMapMessage msg)
        {
            Client.ChangeMap(msg.mapId);
        }

        [MessageHandler]
        public void GameMapMovementRequestMessage(GameMapMovementRequestMessage msg)
        {
            if (msg.mapId != Client.Character.MapId)
            {
                LOGGER.Error($"{Client.Character} try to request move on map#{msg.mapId} but he is on map#{Client.Character.MapId}.");
            }
            else
            {
                var res = PathHelper.GetPathFromKeyMovements(msg.keyMovements);
                nextCellId = res.Last().CellId;
                nextDirection = res.Last().Direction;
                Client.MoveOnMap(msg.keyMovements);
            }
        }

        [MessageHandler]
        public void GameMapMovementConfirmMessage(GameMapMovementConfirmMessage msg)
        {
            if (nextCellId.HasValue)
            {
                Client.Character.CellId = nextCellId.Value;
                Client.Character.Direction = nextDirection.Value;
                Client.Character.Save();
                nextCellId = null;
                nextDirection = null;
                Client.Character.CurrentMap.FinishClientMove(Client);
            }
        }

        [MessageHandler]
        public void GameMapMovementCancelMessage(GameMapMovementCancelMessage msg)
        {
            if (nextCellId.HasValue)
            {
                nextCellId = null;
                nextDirection = null;
                Client.Character.CellId = msg.cellId;
                Client.Character.Save();
                Client.Character.CurrentMap.FinishClientMove(Client);
            }
        }

        [MessageHandler]
        public void GameMapChangeOrientationRequestMessage(GameMapChangeOrientationRequestMessage msg)
        {
            Client.Character.Direction = (DirectionsEnum)msg.direction;
            Client.Character.Save();
            Client.Character.CurrentMap.SendMessageToAll(new GameMapChangeOrientationMessage(Client.Character.ToActorOrientation()));
        }
    }
}
