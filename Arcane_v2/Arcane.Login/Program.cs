﻿using Arcane.Base.Common;
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
        static void Main(string[] args)
        {
            InitMain();
            DatabaseInitializer.Initialize(typeof(Account).Assembly);
            LogConfigInitializer.Initialize(LogLevel.Trace);
            DofusMessageBuilderInitializer.Initialize();
            RSAProtocol.GenerateKey();
            LoginServerManager.Instance.Start();
            LoginServerManager.Instance.OnClientConnected += LoginServerClientConnected;
            LoginServerManager.Instance.OnClientDisconnected += LoginServerClientDisconnected;
            GameLinkManager.Instance.Start();
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
            UpdateConsoleTitle();
        }
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("Erreur : " + e.ExceptionObject);
        }
    }
}
