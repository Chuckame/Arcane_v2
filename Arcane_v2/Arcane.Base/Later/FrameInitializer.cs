using Arcane.IO.TCP.Client;
using Arcane.IO.TCP.Messages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Base.Network
{
    public class FrameInitializer
    {
        private readonly FrameInitializer _mInstance = new FrameInitializer();
        private readonly Dictionary<Type, Tuple<Type, MessageHandler<IMessage>>> _mHandledMessages;

        public IReadOnlyDictionary<Type, Tuple<Type, MessageHandler<IMessage>>> HandledMessages
        {
            get
            {
                return new ReadOnlyDictionary<Type, Tuple<Type, MessageHandler<IMessage>>>(_mHandledMessages);
            }
        }

        public FrameInitializer Instance
        {
            get
            {
                return _mInstance;
            }
        }

        public void RegisterMessageHandler<TFrame, TClient, THandledMessage>(MessageHandler<THandledMessage> messageHandler) where THandledMessage : IMessage where TClient : IClient<TClient> where TFrame : IFrame<TClient>
        {
            if (messageHandler == null)
                throw new ArgumentNullException(nameof(messageHandler));
            _mHandledMessages.Add(typeof(TFrame), new Tuple<Type, MessageHandler<IMessage>>(typeof(THandledMessage), (msg) => messageHandler((THandledMessage)msg)));
        }
    }
}
