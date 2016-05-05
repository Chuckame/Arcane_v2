using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Base.Network
{
    public interface IClient<TClient>
        where TClient : IClient<TClient>
    {
        bool IsConnected { get; }
        IPAddress RemoteHost { get; }
        int RemotePort { get; }
        IReadOnlyCollection<IFrame<TClient>> Frames { get; }
        IMessageFactory MessageFactory { get; }

        event Action<TClient> OnDisconnected;
        event Action<TClient> OnMessageReceiving;
        event Action<TClient, IMessage> OnMessageReceived;
        event Action<TClient, IMessage> OnMessageSending;
        event Action<TClient, IMessage> OnMessageSended;

        void AddFrame(IFrame<TClient> frame);
        void RemoveFrame(IFrame<TClient> frame);
        void SendMessage(IMessage message, bool async = false);
        void Disconnect();
    }
}
