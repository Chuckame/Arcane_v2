using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Base.Network
{
    public interface IClient<TClient>
        where TClient : IClient<TClient>
    {
        string RemoteHost { get; }
        int RemotePort { get; }
        IEnumerable<IFrame<TClient>> Frames { get; }

        event Action OnDisconnected;
        event Action<IMessage> OnMessageReceived;

        void SendData(IMessage message);
    }
}
