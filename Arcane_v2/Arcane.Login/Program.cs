using Arcane.Base.Common;
using Arcane.Base.Encryption;
using Arcane.Login.Network;
using Arcane.Protocol.Messages;
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
            Console.BufferHeight = 500;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            DatabaseConfig.Initialize();
            LogConfig.Initialize();
            MessageBuilder.Instance.Initialize(typeof(MessageBuilder).Assembly);
            RSAProtocol.GenerateKey();
            LoginServerManager.Instance.Start();
            Console.ReadLine();
        }
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("Erreur : " + e.ExceptionObject);
        }
    }
}
