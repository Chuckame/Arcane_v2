using Arcane.Base.Common;
using Arcane.Base.Encryption;
using Arcane.Base.Entities;
using Arcane.Login.Network;
using Arcane.Login.Network.GameLink;
using Arcane.Protocol.Messages;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Login
{
    static class Program
    {
        private static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            InitMain();
            LogConfigInitializer.Initialize(LogLevel.Trace);
            GameLinkManager.Instance.Start();
            DatabaseInitializer.Initialize(typeof(Account).Assembly);
            DofusMessageBuilderInitializer.Initialize();
            RSAProtocol.GenerateKey();
            LoginServerManager.Instance.Start();
            Console.ReadLine();
        }

        private static void LoginServerClientDisconnected(LoginClient obj)
        {
            UpdateConsoleTitle();
        }

        private static void LoginServerClientConnected(LoginClient client)
        {
            UpdateConsoleTitle();
        }

        private static void UpdateConsoleTitle()
        {
            Console.Title = $"HeartEmu - LoginServer - Clients:{LoginServerManager.Instance.Server.Clients.Count}/{LoginServerManager.Instance.Server.MaxConnections}";
        }

        static void InitMain()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Console.BufferHeight = 500;
            LoginServerManager.Instance.OnClientConnected += LoginServerClientConnected;
            LoginServerManager.Instance.OnClientDisconnected += LoginServerClientDisconnected;
            UpdateConsoleTitle();
        }
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            LOGGER.Error("Erreur : " + e.ExceptionObject);
        }
    }
}
