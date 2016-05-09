using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using Chuckame.IO.TCP.Messages;

namespace Chuckame.IO.TCP.Client
{
    /// <summary>
    /// Représente le client d'un serveur TCP.
    /// </summary>
    /// <typeparam name="TClient"></typeparam>
    public interface IClient<TClient, TMessage>
        where TMessage : IMessage
        where TClient : IClient<TClient, TMessage>
    {
        /// <summary>
        /// <code>true</code> si le <see cref="Socket"/> encapsulé est connecté, sinon <code>false</code>.
        /// </summary>
        bool IsConnected { get; }

        /// <summary>
        /// Adresse du hôte distant.
        /// </summary>
        IPAddress RemoteHost { get; }

        /// <summary>
        /// Port du hôte distant.
        /// </summary>
        int RemotePort { get; }

        /// <summary>
        /// Collection non modifiable contenant les <see cref="IFrame{TClient, TMessage}"/> de l'instance en cours.
        /// </summary>
        IReadOnlyCollection<IFrame<TClient, TMessage>> Frames { get; }

        /// <summary>
        /// Instance d'un <see cref="IMessageFactory{TMessage}"/> permettant la création de messages.
        /// </summary>
        IMessageFactory<TMessage> MessageFactory { get; }

        /// <summary>
        /// Evénement déclenché lors de la déconnexion du client.
        /// </summary>
        event Action<TClient> OnDisconnected;

        /// <summary>
        /// Evénement déclenché avant la réception d'un <see cref="TMessage"/>.
        /// </summary>
        event Action<TClient> OnMessageReceiving;

        /// <summary>
        /// Evénement déclenché lorsqu'un <see cref="TMessage"/> est reçu.
        /// </summary>
        event Action<TClient, TMessage> OnMessageReceived;

        /// <summary>
        /// Evénement déclenché avant l'envoi d'un <see cref="TMessage"/>.
        /// </summary>
        event Action<TClient, TMessage> OnMessageSending;

        /// <summary>
        /// Evénement déclenché lorsqu'un <see cref="TMessage"/> a été envoyé.
        /// </summary>
        event Action<TClient, TMessage> OnMessageSent;

        /// <summary>
        /// Ajoute une <see cref="IFrame{TClient, TMessage}"/> dans la collection <see cref="IClient{TClient, TMessage}.Frames"/>.
        /// </summary>
        /// <param name="frame">La <see cref="IFrame{TClient, TMessage}"/> à ajouter.</param>
        void AddFrame(IFrame<TClient, TMessage> frame);

        /// <summary>
        /// Supprime une <see cref="IFrame{TClient, TMessage}"/> de la collection <see cref="IClient{TClient, TMessage}.Frames"/>.
        /// </summary>
        /// <param name="frame">La <see cref="IFrame{TClient, TMessage}"/> à supprimer.</param>
        void RemoveFrame(IFrame<TClient, TMessage> frame);

        /// <summary>
        /// Envoi un <see cref="TMessage"/> au client.
        /// </summary>
        /// <param name="message">Le <see cref="TMessage"/> à envoyer.</param>
        /// <param name="async"><code>true</code> pour envoyer le message en asynchrone, <code>false</code> pour l'envoyer en synchrone.</param>
        void SendMessage(TMessage message, bool async = false);

        /// <summary>
        /// Déconnecte le client.
        /// </summary>
        void Disconnect();
    }
}
