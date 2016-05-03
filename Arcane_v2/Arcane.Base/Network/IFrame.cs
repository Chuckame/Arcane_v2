using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Base.Network
{
    public interface IFrame<TClient>
        where TClient : IClient<TClient>
    {
        IReadOnlyDictionary<Type, Action<TClient, IMessage>> HandledMessages { get; }

        event Action OnAttached;
        event Action OnDetached;

        void RegisterMessageHandler<THandledMessage>(Action<TClient, IMessage> messageHandler) where THandledMessage : IMessage;
    }
}
