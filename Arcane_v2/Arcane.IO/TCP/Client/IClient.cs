using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using Arcane.IO.TCP.Messages;

namespace Arcane.IO.TCP.Client
{
    /// <summary>
    /// Représente le client d'un serveur TCP.
    /// </summary>
    /// <typeparam name="TClient"></typeparam>
    public interface IClient<TClient>
        where TClient : IClient<TClient>
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
        /// Collection non modifiable contenant les <see cref="IFrame{TClient}"/> de l'instance en cours.
        /// </summary>
        IReadOnlyCollection<IFrame<TClient>> Frames { get; }

        /// <summary>
        /// Instance d'un <see cref="IMessageFactory"/> permettant la création de messages.
        /// </summary>
        IMessageFactory MessageFactory { get; }

        /// <summary>
        /// Evénement déclenché lors de la déconnexion du client.
        /// </summary>
        event Action<TClient> OnDisconnected;

        /// <summary>
        /// Evénement déclenché avant la réception d'un <see cref="IMessage"/>.
        /// </summary>
        event Action<TClient> OnMessageReceiving;

        /// <summary>
        /// Evénement déclenché lorsqu'un <see cref="IMessage"/> est reçu.
        /// </summary>
        event Action<TClient, IMessage> OnMessageReceived;

        /// <summary>
        /// Evénement déclenché avant l'envoi d'un <see cref="IMessage"/>.
        /// </summary>
        event Action<TClient, IMessage> OnMessageSending;

        /// <summary>
        /// Evénement déclenché lorsqu'un <see cref="IMessage"/> a été envoyé.
        /// </summary>
        event Action<TClient, IMessage> OnMessageSent;

        /// <summary>
        /// Ajoute une <see cref="IFrame{TClient}"/> dans la collection <see cref="IClient{TClient}.Frames"/>.
        /// </summary>
        /// <param name="frame">La <see cref="IFrame{TClient}"/> à ajouter.</param>
        void AddFrame(IFrame<TClient> frame);

        /// <summary>
        /// Supprime une <see cref="IFrame{TClient}"/> de la collection <see cref="IClient{TClient}.Frames"/>.
        /// </summary>
        /// <param name="frame">La <see cref="IFrame{TClient}"/> à supprimer.</param>
        void RemoveFrame(IFrame<TClient> frame);

        /// <summary>
        /// Envoi un <see cref="IMessage"/> au client.
        /// </summary>
        /// <param name="message">Le <see cref="IMessage"/> à envoyer.</param>
        /// <param name="async"><code>true</code> pour envoyer le message en asynchrone, <code>false</code> pour l'envoyer en synchrone.</param>
        void SendMessage(IMessage message, bool async = false);

        /// <summary>
        /// Déconnecte le client.
        /// </summary>
        void Disconnect();
    }
}
