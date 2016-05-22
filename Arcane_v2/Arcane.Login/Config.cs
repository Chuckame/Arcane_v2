using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Login
{
    internal static class Config
    {
        public static readonly Protocol.Types.Version ExpectedVersion = new Protocol.Types.Version(2, 6, 2, 35100, 0, 0);
        public static readonly IPAddress LoginServerHost = IPAddress.Parse("127.0.0.1");
        public static readonly int LoginServerPort = 444;
        public static readonly int LoginMaxConnections = 1000;
        public static readonly char[] NicknameAcceptedChars = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '-' };
        public static readonly string[] NicknameRefusedWords = { "dofus" };
        public static readonly int NicknameMinLength = 5;
        public static readonly int NicknameMaxLength = 50;
        public static readonly int LoginServerClientIddleTimeout = 60000 * 2;//2 minutes avant déconnexion
    }
}
