using Arcane.Base.Common;
using Arcane.Base.Entities;
using Arcane.Protocol.Enums;
using System;

namespace Arcane.AdminConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "HeartEmu - Admin console";
            DatabaseInitializer.Initialize(typeof(Account).Assembly);
            while (true)
            {
                Console.Write($"{System.Security.Principal.WindowsIdentity.GetCurrent().Name} #> ");
                var commandLine = Console.ReadLine().Split(' ');
                switch (commandLine[0])
                {
                    case "add":
                        DoAdd(commandLine);
                        break;
                    case "stop":
                    case "exit":
                    case "\u0004"://^D
                        return;
                    default:
                        break;
                }
            }
        }
        static void DoAdd(string[] command)
        {
            if (command.Length < 2)
                return;
            switch (command[1])
            {
                case "account":
                    DoAddAccount();
                    break;
                case "server":
                    DoAddServer();
                    break;
                default:
                    break;
            }
        }
        static void DoAddAccount()
        {
            var account = new Account
            {
                AccountCreationDate = DateTime.Now,
                Community = Base.Enums.ServerCommunitiesEnum.French,
            };
            Console.Write("Login: ");
            account.Login = Console.ReadLine();
            Console.Write("Password: ");
            account.Password = Console.ReadLine();
            Console.Write("Nickname: ");
            account.Nickname = Console.ReadLine();
            Console.Write("Is admin[y/n]: ");
            account.IsAdmin = Console.ReadLine().Equals("y", StringComparison.InvariantCultureIgnoreCase);
            Console.Write("Secret question: ");
            account.SecretQuestion = Console.ReadLine();
            Console.Write("Secret response: ");
            account.SecretResponse = Console.ReadLine();
            account.Create();
            Console.WriteLine("Created !");
        }
        static void DoAddServer()
        {
            var server = new GameServerEntity
            {
                CreationDate = DateTime.Now
            };
            Console.Write("Id: ");
            server.Id = ushort.Parse(Console.ReadLine());
            Console.Write("Host: ");
            server.Host = Console.ReadLine();
            Console.Write("Port: ");
            server.Port = ushort.Parse(Console.ReadLine());
            Console.Write("Completion: ");
            server.Completion = sbyte.Parse(Console.ReadLine());
            Console.Write($"Status[{string.Join("|", Enum.GetNames(typeof(ServerStatusEnum)))}]: ");
            var temp = Console.ReadLine();
            server.Status = string.IsNullOrWhiteSpace(temp) || Enum.IsDefined(typeof(ServerStatusEnum), temp) ? ServerStatusEnum.STATUS_UNKNOWN : (ServerStatusEnum)Enum.Parse(typeof(ServerStatusEnum), temp);
            server.Create();
            Console.WriteLine("Created !");
        }
    }
}
