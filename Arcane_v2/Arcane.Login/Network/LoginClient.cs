using Arcane.Base.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace Arcane.Login.Network
{
    public class LoginClient : BaseClient<LoginClient>
    {
        public LoginClient(Socket socket, int bufferSize, IMessageFactory messageFactory) : base(socket, bufferSize, messageFactory)
        {
        }
    }
}
