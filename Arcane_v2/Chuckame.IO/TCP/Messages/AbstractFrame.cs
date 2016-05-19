﻿using Chuckame.IO.TCP.Client;
using NLog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Chuckame.IO.TCP.Messages
{
    public abstract class AbstractFrame<TFrame, TClient, TMessage> : IFrame<TClient, TMessage>
        where TMessage : IMessage
        where TClient : IClient<TClient, TMessage>
    {
        private static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();
        private readonly Dictionary<Type, MethodInfo> _messageHandlers = new Dictionary<Type, MethodInfo>();
        private void Init()
        {
            Console.WriteLine(typeof(TFrame));
            foreach (var method in typeof(TFrame).GetRuntimeMethods())
            {
                var attr = (method.GetCustomAttributes(typeof(MessageHandlerAttribute), false) as MessageHandlerAttribute[]).FirstOrDefault();
                if (attr != null)
                {
                    var parameters = method.GetParameters();
                    if (parameters.Length != 1)
                        throw new NotSupportedException($"The method {method} has MessageHandlerAttribute attribute, but doesn't have only one parameter.");
                    var paramType = parameters[0].ParameterType;
                    if (!paramType.IsSubclassOf(typeof(TMessage)))
                        throw new NotSupportedException($"The method {method} has MessageHandlerAttribute attribute, but the parameter's Type doesn't derive the {typeof(TMessage)} interface.");
                    if (_messageHandlers.ContainsKey(paramType))
                        throw new AmbiguousMatchException($"There's an existing message handler for the message Type '{paramType}'. Ambiguity between {_messageHandlers[paramType]} and {method}");
                    _messageHandlers.Add(paramType, method);
                    LOGGER.Trace($"{typeof(TFrame)}: Message handler added : {method}");
                }
            }
        }
        protected AbstractFrame(TClient client)
        {
            Client = client;
            Init();
        }

        public TClient Client { get; }

        public void Dispatch(TMessage message)
        {
            if (_messageHandlers.ContainsKey(message.GetType()))
            {
                LOGGER.Debug($"{typeof(TFrame)}: {message.GetType()} Caught !");
                try
                {
                    _messageHandlers[message.GetType()].Invoke(this, new object[] { message });
                }
                catch (Exception e)
                {
                    throw new FrameDispatchException($"Exception during frame dispatch on {typeof(TFrame)}.", e);
                }
            }
        }

        public abstract void OnAttached();
        public abstract void OnDettached();


        [Serializable]
        public class FrameDispatchException : Exception
        {
            public FrameDispatchException() { }
            public FrameDispatchException(string message) : base(message) { }
            public FrameDispatchException(string message, Exception inner) : base(message, inner) { }
        }
    }
}