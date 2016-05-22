using Chuckame.IO.TCP.Exceptions;
using Chuckame.IO.TCP.Messages;
using NLog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chuckame.IO.TCP.Client
{
    public abstract class AbstractBaseClient<TClient, TMessage> : IClient<TClient, TMessage>, IDisposable
        where TMessage : IMessage
        where TClient : AbstractBaseClient<TClient, TMessage>
    {
        private readonly Logger LOGGER = LogManager.GetCurrentClassLogger();

        private readonly byte[] _buffer;
        private readonly Queue<TMessage> _messagesQueue;
        private readonly Collection<IFrame<TClient, TMessage>> _mFrames;
        private readonly Socket _socket;
        public bool HasIddleDisconnectionTimeout { get; }
        private readonly Timer _iddleDisconnectionTimer;
        private bool hasSentDisconnection = false;

        protected AbstractBaseClient(Socket socket, int bufferSize, IMessageFactory<TMessage> messageFactory, int? iddleTimeoutDisconnection = null)
        {
            _mFrames = new Collection<IFrame<TClient, TMessage>>();
            _messagesQueue = new Queue<TMessage>();
            _socket = socket;
            BufferSize = bufferSize;
            MessageFactory = messageFactory;
            _buffer = new byte[BufferSize];
            if (HasIddleDisconnectionTimeout = iddleTimeoutDisconnection.HasValue)
            {
                _iddleDisconnectionTimer = new Timer((state) => { OnIddleTimeout?.Invoke((TClient)this); Disconnect(); }, null, iddleTimeoutDisconnection.Value, Timeout.Infinite);
                OnMessageReceived += (a1, a2) => SetIddleDisconnection(iddleTimeoutDisconnection.Value);
                OnMessageReceiving += (a1) => SetIddleDisconnection(iddleTimeoutDisconnection.Value);
                OnMessageSent += (a1, a2) => SetIddleDisconnection(iddleTimeoutDisconnection.Value);
                OnMessageReceived += (a1, a2) => SetIddleDisconnection(iddleTimeoutDisconnection.Value);
            }
            new Thread(() => BeginReceive(new StateObject())) { Name = $"{typeof(TClient).Name}Thread" }.Start();
        }

        public event Action<TClient> OnDisconnected;
        public event Action<TClient, TMessage> OnMessageReceived;
        public event Action<TClient> OnMessageReceiving;
        public event Action<TClient, TMessage> OnMessageSending;
        public event Action<TClient, TMessage> OnMessageSent;
        public event Action<TClient> OnIddleTimeout;
        private event Action<TMessage> _dispatchMessageEvent;

        public int BufferSize { get; }

        public IReadOnlyCollection<IFrame<TClient, TMessage>> Frames
        {
            get
            {
                return _mFrames;
            }
        }

        public bool IsConnected
        {
            get
            {
                return _socket.Connected;
            }
        }

        public IMessageFactory<TMessage> MessageFactory { get; }

        public IPAddress RemoteHost
        {
            get
            {
                return ((IPEndPoint)_socket.RemoteEndPoint).Address;
            }
        }

        public int RemotePort
        {
            get
            {
                return ((IPEndPoint)_socket.RemoteEndPoint).Port;
            }
        }

        public void SetIddleDisconnection(int iddleDisconnection)
        {
            if (HasIddleDisconnectionTimeout)
                _iddleDisconnectionTimer.Change(iddleDisconnection, Timeout.Infinite);
            else
                LOGGER.Error("There is no iddle disconnection.");
        }

        public void AddFrame(IFrame<TClient, TMessage> frame)
        {
            LOGGER.Trace($"Adding frame '{frame}'...");
            _mFrames.Add(frame);
            _dispatchMessageEvent += frame.Dispatch;
            frame.NotifyAttachment();
        }

        public IFrame<TClient, TMessage> GetFrame<TFrame>() where TFrame : IFrame<TClient, TMessage>
        {
            return _mFrames.FirstOrDefault(f => f is TFrame);
        }

        public void Disconnect()
        {
            lock (_socket)
            {
                if (IsConnected || !hasSentDisconnection)
                {
                    LOGGER.Trace($"Disconnection...");
                    try
                    {
                        _socket.Disconnect(false);
                        OnDisconnected?.Invoke((TClient)this);
                        hasSentDisconnection = true;
                    }
                    catch (SocketException)
                    {
                        LOGGER.Trace($"Unable to disconnect, already disconnected.");
                    }
                }
                else
                {
                    LOGGER.Trace($"Already disconnected, useless to disconnect.");
                }
            }
        }

        public void Dispose()
        {
            if (IsConnected)
            {
                Disconnect();
            }
            _socket.Dispose();
            _iddleDisconnectionTimer.Dispose();
        }

        public void RemoveFrame(IFrame<TClient, TMessage> frame)
        {
            LOGGER.Trace($"Removing frame '{frame}'...");
            _mFrames.Remove(frame);
            _dispatchMessageEvent -= frame.Dispatch;
            frame.NotifyDetachment();
        }

        public void SendMessage(TMessage message, bool async = false)
        {
            LOGGER.Debug($"Sending message ({message}) :");
            OnMessageSending?.Invoke((TClient)this, message);
            LOGGER.Trace($"Serializing...");
            var buffer = MessageFactory.SerializeMessage(message);
            LOGGER.Trace($"Sending...");
            try
            {
                var asyncResult = _socket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, MessageSentCallback, message);
                if (!async)
                {
                    LOGGER.Trace($"Asynchronous sending, waiting for the end of the shipment...");
                    asyncResult.AsyncWaitHandle.WaitOne();
                }
            }
            catch (SocketException)
            {
                LOGGER.Trace($"Disconnection during sending !");
                Disconnect();
            }
        }

        /// <summary>
        /// Nettoie le buffer de réception et commence une réception asynchrone.
        /// </summary>
        /// <param name="state"></param>
        private void BeginReceive(StateObject state)
        {
            LOGGER.Trace($"Begin receive [state:{state}]");
            try
            {
                _socket.BeginReceive(_buffer, 0, BufferSize, SocketFlags.None, MessageReceivedCallback, state);
            }
            catch (SocketException)
            {
                Disconnect();
            }
        }
        private void MessageReceivedCallback(IAsyncResult ar)
        {
            LOGGER.Trace($"Receiving datas...");
            if (!IsConnected)
            {
                Disconnect();
                return;
            }
            var stateObject = (StateObject)ar.AsyncState;
            int bytesRead;
            try
            {
                bytesRead = _socket.EndReceive(ar);
            }
            catch (SocketException)
            {
                Disconnect();
                return;
            }

            //encore des données à recevoir pour former le msg final
            if (bytesRead > 0)
            {
                //première réception du msg, donc encore rien de lu
                if (stateObject.Parts.Count == 0)
                {
                    OnMessageReceiving?.Invoke((TClient)this);
                }
                var partBuffer = new byte[bytesRead];
                Array.Copy(_buffer, partBuffer, bytesRead);
                stateObject.Parts.Add(partBuffer);
                LOGGER.Trace($"Received part. Parts number : {stateObject.Parts.Count}");
                ICollection<TMessage> messages;
                if (MessageFactory.TryBuildMessages(stateObject.CombineParts(), out messages))
                {
                    MessagesReceived(messages);
                }
                else
                {
                    BeginReceive(stateObject);
                }
            }
            //message entier reçu
            else
            {
                //là, rien de reçu du tout !
                if (stateObject.Parts.Count == 0)
                {
                    LOGGER.Trace($"Empty reception, going to disconnect...");
                    Disconnect();
                }
                else
                {
                    LOGGER.Trace($"Part combination ({stateObject.Parts.Count} parts).");
                    var finalBuffer = stateObject.CombineParts();
                    LOGGER.Trace($"Building messages from combined parts...");
                    ICollection<TMessage> messages;
                    if (MessageFactory.TryBuildMessages(finalBuffer, out messages))
                    {
                        LOGGER.Debug($"Data received: {finalBuffer.Length} bytes, messages built: {messages.Count()}.");
                        MessagesReceived(messages);
                    }
                    else
                    {
                        LOGGER.Debug($"Data received: {finalBuffer.Length} bytes, but no messages built. Maybe there's problems !");
                        BeginReceive(new StateObject());
                    }
                }
            }
        }

        private void MessagesReceived(ICollection<TMessage> messages)
        {
            LOGGER.Trace($"{messages.Count()} messages received : [{string.Join(",", messages.Select(m => m.GetType()))}]");
            LOGGER.Trace($"Notifying for messages...");
            try
            {
                foreach (var msg in messages)
                {
                    DispatchMessage(msg);
                }
            }
            catch (Exception e)
            {
                throw new NetworkException("Exception during dispatch.", e);
            }
            if (IsConnected)
            {
                BeginReceive(new StateObject());
            }
        }

        public void DispatchMessage(TMessage message)
        {
            OnMessageReceived?.Invoke((TClient)this, message);
            _dispatchMessageEvent?.Invoke(message);
        }

        private void MessageSentCallback(IAsyncResult ar)
        {
            LOGGER.Trace($"Message sent !");
            OnMessageSent?.Invoke((TClient)this, (TMessage)ar.AsyncState);
        }
        private class StateObject
        {
            public readonly Collection<byte[]> Parts = new Collection<byte[]>();
            public byte[] CombineParts()
            {
                var result = new byte[Parts.Sum(x => x.Length)];
                var i = 0;
                foreach (var part in Parts)
                {
                    part.CopyTo(result, i);
                    i += part.Length;
                }
                return result;
            }
            public override string ToString()
            {
                return $"{nameof(StateObject)}(Parts:{Parts.Count})";
            }
        }
    }
}
