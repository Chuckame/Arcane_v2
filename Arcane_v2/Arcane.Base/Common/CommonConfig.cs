using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Base.Common
{
    public static class CommonConfig
    {
        public static readonly string DatabaseConfigFileName = "database.xml";
        public static readonly IPAddress GameLinkHost = IPAddress.Parse("127.0.0.1");
        public static readonly int GameLinkPort = 4445;
        public static readonly int GameLinkMaxConnections = 100;
    }
}
