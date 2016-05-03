using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Base.Network
{
    public abstract class Frame<TClient> : IFrame<TClient>
        where TClient : IClient<TClient>
    {
        private readonly Dictionary<Type, Action<TClient, IMessage>> _mHandledMessages;

        protected Frame()
        {
        }

        public event Action OnAttached;
        public event Action OnDetached;

        public IReadOnlyDictionary<Type, Action<TClient, IMessage>> HandledMessages
        {
            get
            {
                return new ReadOnlyDictionary<Type, Action<TClient, IMessage>>(_mHandledMessages);
            }
        }

        public void RegisterMessageHandler<THandledMessage>(Action<TClient, IMessage> messageHandler) where THandledMessage : IMessage
        {
            if (messageHandler == null)
                throw new ArgumentNullException(nameof(messageHandler));
            _mHandledMessages.Add(typeof(THandledMessage), messageHandler);
        }
    }
}
