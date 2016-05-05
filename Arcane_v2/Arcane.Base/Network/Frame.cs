﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Base.Network
{
    public abstract class AbstractFrame<TClient> : IFrame<TClient>
        where TClient : IClient<TClient>
    {
        protected AbstractFrame(TClient client)
        {
            Client = client;
        }

        public TClient Client { get; }

        public abstract bool Dispatch(IMessage message);
    }
}
