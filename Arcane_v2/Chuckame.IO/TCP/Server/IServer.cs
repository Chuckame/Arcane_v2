using Chuckame.IO.TCP.Client;
using Chuckame.IO.TCP.Exceptions;
using Chuckame.IO.TCP.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Chuckame.IO.TCP.Server
{
    /// <summary>
    /// Représente un serveur TCP.
    /// </summary>
    /// <typeparam name="TServer"></typeparam>
    /// <typeparam name="TClient"></typeparam>
    public interface IServer<TServer, TClient, TMessage> : IDisposable
        where TMessage : IMessage
        where TClient : IClient<TClient, TMessage>
        where TServer : IServer<TServer, TClient, TMessage>
    {
        /// <summary>
        /// Adresse d'écoute.
        /// </summary>
        IPAddress Host { get; }

        /// <summary>
        /// Port d'écoute.
        /// </summary>
        int Port { get; }

        /// <summary>
        /// Indique si le serveur est lancé ou non.
        /// </summary>
        bool IsStarted { get; }

        /// <summary>
        /// Collection non modifiable contenant tous les clients connectés à ce serveur.
        /// </summary>
        IReadOnlyCollection<TClient> Clients { get; }

        /// <summary>
        /// Instance d'un <see cref="IClientFactory{TClient, TMessage}"/> permettant la création de clients lors de l'acceptation d'une <see cref="Socket"/>.
        /// </summary>
        IClientFactory<TClient, TMessage> ClientFactory { get; }

        /// <summary>
        /// Evénement déclenché lorsqu'un <see cref="TClient"/> se connecte sur le serveur.
        /// </summary>
        event Action<TServer, TClient> OnClientAccepted;

        /// <summary>
        /// Evénement déclenché avant le démarrage du serveur.
        /// </summary>
        event Action<TServer> OnStarting;

        /// <summary>
        /// Evénement déclenché lors de la fin du démarrage du serveur.
        /// </summary>
        event Action<TServer> OnStarted;

        /// <summary>
        /// Evénement déclenché avant l'extinction du serveur.
        /// </summary>
        event Action<TServer> OnStopping;

        /// <summary>
        /// Evénement déclenché lors de la fin de l'extinction du serveur.
        /// </summary>
        event Action<TServer> OnStopped;

        /// <summary>
        /// Démarre l'écoute du serveur sur un port et une adresse donnée.
        /// </summary>
        /// <exception cref="AlreadyStartedException"></exception>
        void Start();

        /// <summary>
        /// Arrête le serveur et déconnecte tous les clients en appelant <see cref="IServer{TServer, TClient, TMessage}.DisconnectAll"/>.
        /// </summary>
        /// <exception cref="AlreadyStoppedException"></exception>
        void Stop();

        /// <summary>
        /// Déconnecte tous les clients.
        /// </summary>
        void DisconnectAll();
    }
}
