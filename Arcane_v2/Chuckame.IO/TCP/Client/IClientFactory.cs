using Chuckame.IO.TCP.Messages;
using System.Net.Sockets;

namespace Chuckame.IO.TCP.Client
{
    /// <summary>
    /// Usine permettant la création d'un <see cref="TClient"/> à partir d'une <see cref="Socket"/>.
    /// </summary>
    /// <typeparam name="TClient"></typeparam>
    public interface IClientFactory<TClient, TMessage>
        where TMessage : IMessage
        where TClient : IClient<TClient, TMessage>
    {
        /// <summary>
        /// Crée un <see cref="TClient"/> à partir d'une <see cref="Socket"/>.
        /// </summary>
        /// <param name="socket"></param>
        /// <returns></returns>
        TClient createClient(Socket socket);
    }
}