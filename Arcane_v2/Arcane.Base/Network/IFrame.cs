using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Base.Network
{
    public interface IFrame<TClient, TMessage>
        where TMessage : IMessage
        where TClient : IClient<TClient, TMessage>
    {
        IDictionary<Type, Action<TClient, TMessage>> HandledMessages { get; }

        event Action OnAttached;
        event Action OnDetached;

        void RegisterMessageHandler<THandledMessage>(Action<TClient, THandledMessage> messageHandler) where THandledMessage : TMessage;
    }
}
