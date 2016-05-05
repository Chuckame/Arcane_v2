using Arcane.IO.TCP.Messages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.IO.TCP.Client
{
    public class BaseClient<TClient> : IClient<TClient>, IDisposable
        where TClient : BaseClient<TClient>
    {
        private readonly byte[] _buffer;
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
            _buffer = new byte[BufferSize];
            BeginReceive(new StateObject());
        }

        public event Action<TClient> OnDisconnected;
        public event Action<TClient, IMessage> OnMessageReceived;
        public event Action<TClient> OnMessageReceiving;
        public event Action<TClient, IMessage> OnMessageSending;
        public event Action<TClient, IMessage> OnMessageSent;
        private event Action<IMessage> _dispatchMessageEvent;

        public int BufferSize { get; }

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
            _dispatchMessageEvent += frame.Dispatch;
        }

        public void Disconnect()
        {
            _socket.Disconnect(false);
            OnDisconnected?.Invoke((TClient)this);
        }

        public void Dispose()
        {
            if (IsConnected)
            {
                Disconnect();
            }
            _socket.Dispose();
        }

        public void RemoveFrame(IFrame<TClient> frame)
        {
            _mFrames.Remove(frame);
            _dispatchMessageEvent -= frame.Dispatch;
        }

        public void SendMessage(IMessage message, bool async = false)
        {
            OnMessageSending?.Invoke((TClient)this, message);
            var buffer = message.Serialize();
            var asyncResult = _socket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, MessageSentCallback, message);
            if (!async)
            {
                asyncResult.AsyncWaitHandle.WaitOne();
            }
        }

        /// <summary>
        /// Nettoie le buffer de réception et commence une réception asynchrone.
        /// </summary>
        /// <param name="state"></param>
        private void BeginReceive(StateObject state)
        {
            Array.Clear(_buffer, 0, BufferSize);
            _socket.BeginReceive(_buffer, 0, BufferSize, SocketFlags.None, MessageReceivedCallback, state);
        }
        private void MessageReceivedCallback(IAsyncResult ar)
        {
            if (!IsConnected)
            {
                Disconnect();
                return;
            }
            var stateObject = (StateObject)ar.AsyncState;
            var bytesRead = _socket.EndReceive(ar);

            //encore des données à recevoir pour former le msg final
            if (bytesRead > 0)
            {
                //première réception du msg, donc encore rien de lu
                if (stateObject.Tries == 0)
                {
                    OnMessageReceiving?.Invoke((TClient)this);
                }
                var partBuffer = new byte[bytesRead];
                Array.Copy(_buffer, partBuffer, bytesRead);
                stateObject.Parts.Add(partBuffer);
                stateObject.Tries++;
                BeginReceive(stateObject);
            }
            //message entier reçu
            else
            {
                //là, rien de reçu du tout !
                if (stateObject.Tries == 0)
                {
                    Disconnect();
                }
                else
                {
                    var finalBuffer = stateObject.CombineParts();
                    var messages = MessageFactory.buildMessages(finalBuffer);
                    foreach (var msg in messages)
                    {
                        OnMessageReceived?.Invoke((TClient)this, msg);
                        _dispatchMessageEvent?.Invoke(msg);
                    }
                    if (IsConnected)
                    {
                        BeginReceive(new StateObject());
                    }
                }
            }
        }

        private void MessageSentCallback(IAsyncResult ar)
        {
            OnMessageSent?.Invoke((TClient)this, (IMessage)ar.AsyncState);
        }
        private class StateObject
        {
            public readonly Collection<byte[]> Parts = new Collection<byte[]>();
            public int Tries;
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

        }
    }
}
