using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Base.Network
{
    /// <summary>
    /// Usine permettant la création de <see cref="IMessage"/>(s) depuis des données brutes.
    /// </summary>
    public interface IMessageFactory
    {
        /// <summary>
        /// Crée, si possible, un ou plusieurs <see cref="IMessage"/>(s) depuis des données brutes.
        /// </summary>
        /// <param name="raw">Données brutes à convertir.</param>
        /// <returns></returns>
        IEnumerable<IMessage> buildMessages(byte[] raw);
    }
}
