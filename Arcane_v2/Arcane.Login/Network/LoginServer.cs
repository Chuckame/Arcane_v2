using Arcane.Base.Network;
using Arcane.Base.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Login.Network
{
    public class LoginServer : AbstractServer<LoginClient>, ISingleton<LoginServer>
    {
        private readonly LoginServer _mInstance = new LoginServer();

        private LoginServer()
        {

        }

        public LoginServer Instance
        {
            get
            {
                return _mInstance;
            }
        }
    }
}
