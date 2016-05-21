using Arcane.Base.Network.GameLink;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using NLog;
using Arcane.Base.Common;
using Arcane.Base.Network.GameLink.Messages;
using Arcane.Protocol.Enums;
using Arcane.Game.Network.GameLink.Frames;

namespace Arcane.Game.Network.GameLink
{
    public class GameLinkConnectorManager
    {
        private static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();
        #region Singleton
        private static GameLinkConnectorManager _instance = new GameLinkConnectorManager();

        public static GameLinkConnectorManager Instance
        {
            get
            {
                return _instance;
            }
        }
        #endregion
        public bool IsStarted { get; private set; }
        public GameLinkConnector Connector { get; private set; }
        public event Action<GameLinkConnector, ServerStatusEnum> OnStatusUpdated;
        public TicketManager TicketManager { get; }
        private ServerStatusEnum _mServerStatus = ServerStatusEnum.OFFLINE;
        public ServerStatusEnum ServerStatus
        {
            get
            {
                return _mServerStatus;
            }
            set
            {
                if (value != _mServerStatus)
                {
                    _mServerStatus = value;
                    OnStatusUpdated?.Invoke(Connector, _mServerStatus);
                }
            }
        }
        private GameLinkConnectorManager()
        {
            TicketManager = new TicketManager();
            OnStatusUpdated += GameLinkConnectorManager_OnStatusUpdated;
        }

        private void GameLinkConnectorManager_OnStatusUpdated(GameLinkConnector connector, ServerStatusEnum newStatus)
        {
            if (IsStarted)
            {
                connector.SendMessage(new StatusMessage { Status = newStatus });
            }
        }

        public void Connect()
        {
            if (!IsStarted)
            {
                LOGGER.Info($"Connecting to {CommonConfig.GameLinkHost}:{CommonConfig.GameLinkPort}...");
                var socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(CommonConfig.GameLinkHost, CommonConfig.GameLinkPort);
                LOGGER.Debug($"Connected !");
                Connector = new GameLinkConnector(socket);
                Connector.AddFrame(new BeforeFrame(Connector));
                IsStarted = true;
            }
        }

        public void Disconnect()
        {
            if (IsStarted)
            {
                Connector.Disconnect();
                IsStarted = false;
            }
        }
    }
}
