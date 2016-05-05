using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Base.Network
{
    /// <summary>
    /// Cette classe permet la répartition d'un message.
    /// </summary>
    /// <typeparam name="TClient"></typeparam>
    public interface IFrame<TClient>
        where TClient : IClient<TClient>
    {
        TClient Client { get; }

        /// <summary>
        /// Prend en charge un message si possible.
        /// </summary>
        /// <param name="message"></param>
        void Dispatch(IMessage message);
    }
}
