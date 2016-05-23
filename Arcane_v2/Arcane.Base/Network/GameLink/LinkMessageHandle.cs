using Arcane.Base.Network.GameLink.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Arcane.Base.Network.GameLink
{
    public class LinkMessageHandle
    {
        public AbstractGameLinkMessage Message { get; private set; }
        public Predicate<AbstractGameLinkMessage> ExpectedMessagePredicate { get; private set; }
        private AutoResetEvent AutoResetEvent;
        private bool IsReset = false;

        public LinkMessageHandle(Predicate<AbstractGameLinkMessage> expectedMessagePredicate)
        {
            AutoResetEvent = new AutoResetEvent(false);
            ExpectedMessagePredicate = expectedMessagePredicate;
        }

        public bool Set(AbstractGameLinkMessage message)
        {
            Message = message;
            return AutoResetEvent.Set();
        }

        public void Break()
        {
            lock (this)
            {
                IsReset = true;
                AutoResetEvent.Set();
            }
        }

        public bool IsExpectedMessage(AbstractGameLinkMessage message)
        {
            return ExpectedMessagePredicate(message);
        }
        
        public AbstractGameLinkMessage WaitMessage(int? millisecondsTimeout = null)
        {
            lock (this)
            {
                bool timeout;
                if (millisecondsTimeout.HasValue)
                    timeout = !AutoResetEvent.WaitOne(millisecondsTimeout.Value);
                else
                    timeout = !AutoResetEvent.WaitOne();
                if (IsReset)
                    throw new HandleResetException();
                if (timeout)
                    throw new HandleTimeoutException();
                return Message;
            }
        }

        [Serializable]
        public class HandleResetException : Exception
        {
            public HandleResetException() { }
        }

        [Serializable]
        public class HandleTimeoutException : Exception
        {
            public HandleTimeoutException() { }
        }
    }
}
