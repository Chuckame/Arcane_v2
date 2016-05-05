using System.Net.Sockets;

namespace Arcane.Base.Network
{
    public interface IClientFactory<TClient> where TClient : IClient<TClient>
    {
        TClient createClient(Socket client);
    }
}