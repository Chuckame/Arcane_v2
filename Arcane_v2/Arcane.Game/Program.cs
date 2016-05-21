using Arcane.Base.Common;
using Arcane.Base.Encryption;
using Arcane.Base.Entities;
using Arcane.Game.Network;
using Arcane.Game.Network.GameLink;
using Arcane.Protocol.Messages;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Game
{
    static class Program
    {
        static void Main(string[] args)
        {
            InitMain();
            LogConfigInitializer.Initialize(LogLevel.Trace);
            DatabaseInitializer.Initialize(typeof(Account).Assembly/*, typeof(Character).Assembly*/);
            GameLinkConnectorManager.Instance.ServerStatus = Protocol.Enums.ServerStatusEnum.STARTING;
            GameLinkConnectorManager.Instance.Connect();
            DofusMessageBuilderInitializer.Initialize();
            RSAProtocol.GenerateKey();
            GameServerManager.Instance.Start();
            GameLinkConnectorManager.Instance.ServerStatus = Protocol.Enums.ServerStatusEnum.ONLINE;
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
        }

        private static void LoginServerClientDisconnected(GameClient obj)
        {
            UpdateConsoleTitle();
        }

        private static void LoginServerClientConnected(GameClient client)
        {
            UpdateConsoleTitle();
        }

        private static void UpdateConsoleTitle()
        {
            Console.Title = $"HeartEmu - GameServer - Clients:{GameServerManager.Instance.Server.Clients.Count}/{GameServerManager.Instance.Server.MaxConnections}";
        }

        static void InitMain()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Console.BufferHeight = 500;
            GameServerManager.Instance.OnClientConnected += LoginServerClientConnected;
            GameServerManager.Instance.OnClientDisconnected += LoginServerClientDisconnected;
            UpdateConsoleTitle();
        }
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("Erreur : " + e.ExceptionObject);
        }
    }
}
