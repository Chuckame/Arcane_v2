using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Base.Network
{
    public delegate void MessageHandler<in TClient, in TMessage>(TClient client, TMessage message) where TClient : IClient<TClient> where TMessage : NetworkMessage;
}
