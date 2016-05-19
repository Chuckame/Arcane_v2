using Arcane.Base.Database;
using Arcane.Base.Encryption;
using Arcane.Login;
using Arcane.Login.Frames;
using Arcane.Login.Helpers;
using Arcane.Login.Network;
using Arcane.Protocol.Messages;
using Chuckame.IO.TCP.Messages;
using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Arcane
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BufferHeight = 5000;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Database.Init();
            LogManager.Configuration = GetLogConf();
            MessageBuilder.Instance.Initialize(typeof(MessageBuilder).Assembly);
            RSAProtocol.GenerateKey();
            LoginServerManager.Instance.Initialize(Config.LoginServerHost, Config.LoginServerPort, Config.LoginMaxConnections);
            LoginServerManager.Instance.Start();
            Console.ReadLine();
        }
        private static LoggingConfiguration GetLogConf()
        {
            var config = new LoggingConfiguration();
            var consoleTarget = new ColoredConsoleTarget();
            config.AddTarget("console", consoleTarget);
            consoleTarget.Layout = @"${threadid}|${longdate}|${level}|${callsite}()|${message}";
            var rule1 = new LoggingRule("*", LogLevel.Trace, consoleTarget);
            config.LoggingRules.Add(rule1);
            return config;
        }
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("Erreur : " + e.ExceptionObject);
        }
    }
}
