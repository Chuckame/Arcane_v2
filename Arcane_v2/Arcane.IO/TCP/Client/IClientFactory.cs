using System.Net.Sockets;

namespace Arcane.IO.TCP.Client
{
    /// <summary>
    /// Usine permettant la création d'un <see cref="TClient"/> à partir d'une <see cref="Socket"/>.
    /// </summary>
    /// <typeparam name="TClient"></typeparam>
    public interface IClientFactory<TClient> where TClient : IClient<TClient>
    {
        /// <summary>
        /// Crée un <see cref="TClient"/> à partir d'une <see cref="Socket"/>.
        /// </summary>
        /// <param name="socket"></param>
        /// <returns></returns>
        TClient createClient(Socket socket);
    }
}