using Arcane.Base.Network.Messages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Base.Network
{
    public class BaseClient<TClient> : IClient<TClient>, IDisposable
        where TClient : BaseClient<TClient>
    {
        private byte[] _buffer;
        private readonly Queue<IMessage> _messagesQueue;
        private readonly Collection<IFrame<TClient>> _mFrames;
        private readonly Socket _socket;

        public BaseClient(Socket socket, int bufferSize, IMessageFactory messageFactory)
        {
            _mFrames = new Collection<IFrame<TClient>>();
            _messagesQueue = new Queue<IMessage>();
            _socket = socket;
            BufferSize = bufferSize;
            MessageFactory = messageFactory;
            BeginReceive(new StateObject());
        }

        /// <summary>
        /// Nettoie le buffer de réception et commence une réception asynchrone.
        /// </summary>
        /// <param name="state"></param>
        private void BeginReceive(StateObject state)
        {
            _buffer = new byte[BufferSize];
            _socket.BeginReceive(_buffer, 0, BufferSize, SocketFlags.None, MessageReceivedCallback, state);
        }

        public event Action<TClient> OnDisconnected;
        public event Action<TClient, IMessage> OnMessageReceived;
        public event Action<TClient, IMessage> OnMessageSended;
        public event Action<TClient> OnMessageReceiving;
        public event Action<TClient, IMessage> OnMessageSending;

        public IReadOnlyCollection<IFrame<TClient>> Frames
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

        public int BufferSize { get; }

        public IMessageFactory MessageFactory { get; }

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

        public void AddFrame(IFrame<TClient> frame)
        {
            _mFrames.Add(frame);
        }

        public void Disconnect()
        {
            _socket.Disconnect(false);
            OnDisconnected?.Invoke((TClient)this);
        }

        public void RemoveFrame(IFrame<TClient> frame)
        {
            _mFrames.Remove(frame);
        }

        public void SendMessage(IMessage message, bool async = false)
        {
            OnMessageSending?.Invoke((TClient)this, message);
            var buffer = message.Serialize();
            var asyncResult = _socket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, MessageSendedCallback, message);
            if (!async)
            {
                asyncResult.AsyncWaitHandle.WaitOne();
            }
        }

        private void MessageSendedCallback(IAsyncResult ar)
        {
            OnMessageSended?.Invoke((TClient)this, (IMessage)ar.AsyncState);
        }
        class StateObject
        {
            public readonly Collection<byte[]> Parts = new Collection<byte[]>();

        }
        private byte[] CombineParts(StateObject stateObject)
        {
            var result = new byte[stateObject.Parts.Sum(x => x.Length)];
            var i = 0;
            foreach (var part in stateObject.Parts)
            {
                part.CopyTo(result, i);
                i += part.Length;
            }
            return result;
        }
        private void MessageReceivedCallback(IAsyncResult ar)
        {
            var stateObject = (StateObject)ar.AsyncState;
            //première réception du msg, donc encore rien de lu
            //if (stateObject.Parts.Count < 1 && _socket.Available < 1)
            //    return;
            if (stateObject.Parts.Count < 1)
            {
                OnMessageReceiving?.Invoke((TClient)this);
            }
            var bytesRead = _socket.EndReceive(ar);

            //encore des données à recevoir pour former le msg final
            if (bytesRead > 0)
            {
                Array.Resize(ref _buffer, bytesRead);
                stateObject.Parts.Add(_buffer);
                BeginReceive(stateObject);
            }
            //message entier reçu
            else
            {
                var finalBuffer = CombineParts(stateObject);
                var messages = MessageFactory.buildMessages(finalBuffer);
                foreach (var msg in messages)
                {
                    OnMessageReceived?.Invoke((TClient)this, msg);
                }
                if (IsConnected)
                {
                    BeginReceive(new StateObject());
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
        }
    }
}
