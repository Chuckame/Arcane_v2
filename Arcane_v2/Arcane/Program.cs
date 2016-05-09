using Arcane.Base.Encryption;
using Arcane.Login.Frames;
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
            var config = new LoggingConfiguration();

            // Step 2. Create targets and add them to the configuration 
            var consoleTarget = new ColoredConsoleTarget();
            config.AddTarget("console", consoleTarget);

            // Step 3. Set target properties 
            consoleTarget.Layout = @"${threadid}|${longdate}|${level}|${logger}|${message}";

            // Step 4. Define rules
            var rule1 = new LoggingRule("*", LogLevel.Trace, consoleTarget);
            config.LoggingRules.Add(rule1);

            // Step 5. Activate the configuration
            LogManager.Configuration = config;
            MessageBuilder.Instance.Initialize(typeof(MessageBuilder).Assembly);
            RSAProtocol.GenerateKey();
            var server = new LoginServer(System.Net.IPAddress.Parse("127.0.0.1"), 443, 1000);
            server.Start();
            using (var client = new TcpClient("127.0.0.1", 443))
            {
                //client.Connect(System.Net.IPAddress.Parse("127.0.0.1"), 443);
                using (var loginClient = new LoginClient(client.Client))
                {
                    loginClient.OnMessageReceived += LoginClient_OnMessageReceived;
                    Console.ReadLine();
                }
            }
            Console.ReadLine();
            server.Dispose();
        }

        private static void LoginClient_OnMessageReceived(LoginClient arg1, Protocol.AbstractMessage arg2)
        {
            Console.WriteLine("MAIN: msg received");
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("Erreur : " + e.ExceptionObject);
        }
    }
}
