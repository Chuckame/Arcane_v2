using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Base.Network
{
    public interface IClient<TClient, TMessage>
        where TClient : IClient<TClient, TMessage>
        where TMessage : IMessage
    {
        string RemoteHost { get; }
        int RemotePort { get; }
        IEnumerable<IFrame<TClient, TMessage>> Frames { get; }

        event Action OnDisconnected;
        event Action<TMessage> OnMessageReceived;

        void SendData(TMessage message);
    }
}
