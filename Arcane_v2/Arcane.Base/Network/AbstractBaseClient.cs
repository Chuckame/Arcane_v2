﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Base.Network
{
    public abstract class AbstractBaseClient<TClient> : IClient<TClient, NetworkMessage>
        where TClient : AbstractBaseClient<TClient>
    {
        private readonly IEnumerable<IFrame<TClient, NetworkMessage>> _mFrames;
        private readonly string _mRemoteHost;
        private readonly int _mRemotePort;

        public event Action OnDisconnected;
        public event Action<NetworkMessage> OnMessageReceived;

        public IEnumerable<IFrame<TClient, NetworkMessage>> Frames
        {
            get
            {
                return _mFrames;
            }
        }

        public string RemoteHost
        {
            get
            {
                return _mRemoteHost;
            }
        }

        public int RemotePort
        {
            get
            {
                return _mRemotePort;
            }
        }

        public void SendData(NetworkMessage message)
        {
            throw new NotImplementedException();
        }
    }
}
