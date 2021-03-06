﻿using Chuckame.IO.TCP.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chuckame.IO.TCP.Messages
{
    /// <summary>
    /// Cette classe permet la répartition d'un message.
    /// </summary>
    /// <typeparam name="TClient"></typeparam>
    public interface IFrame<TClient, TMessage>
        where TClient : IClient<TClient, TMessage>
        where TMessage : IMessage
    {
        TClient Client { get; }

        /// <summary>
        /// Prend en charge un message si possible.
        /// </summary>
        /// <param name="message"></param>
        void Dispatch(TMessage message);

        event Action OnFrameAttached;
        event Action OnFrameDetached;

        void NotifyAttachment();
        void NotifyDetachment();

        /// <summary>
        /// Ajoute des frames dépendantes de cette instance. Lors d'un OnFrameAttached ou OnFrameDetached, ces frames seront elles aussi attachées ou détachées.
        /// </summary>
        /// <param name="frames"></param>
        void AddDependencies(params IFrame<TClient, TMessage>[] frames);
    }
}
