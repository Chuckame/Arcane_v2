using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Base.Network
{
    public abstract class Frame<TClient, TMessage> : IFrame<TClient, TMessage>
        where TMessage : IMessage
        where TClient : IClient<TClient, TMessage>
    {
        private readonly IDictionary<Type, Action<TClient, TMessage>> _mHandledMessages;

        protected Frame()
        {
        }

        public event Action OnAttached;
        public event Action OnDetached;

        public IDictionary<Type, Action<TClient, TMessage>> HandledMessages
        {
            get
            {
                return _mHandledMessages;
            }
        }

        public void RegisterMessageHandler<THandledMessage>(Action<TClient, THandledMessage> messageHandler) where THandledMessage : TMessage
        {
            if (messageHandler == null)
                throw new ArgumentNullException(nameof(messageHandler));
            _mHandledMessages.Add(typeof(THandledMessage), new Action<TClient, TMessage>((c, m) => messageHandler(c, (THandledMessage)m)));
        }
    }
}
