using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chuckame.IO.TCP.Messages
{
    /// <summary>
    /// Usine permettant la création de <see cref="IMessage"/>(s) depuis des données brutes.
    /// </summary>
    public interface IMessageFactory<TMessage> where TMessage : IMessage
    {
        /// <summary>
        /// Crée, si possible, un ou plusieurs <see cref="IMessage"/>(s) depuis des données brutes.
        /// </summary>
        /// <param name="raw">Données brutes à convertir.</param>
        /// <returns></returns>
        IEnumerable<TMessage> buildMessages(byte[] raw);

        /// <summary>
        /// Sérialise un message en un tableau d'octet.
        /// </summary>
        /// <param name="message">Message à sérialiser.</param>
        /// <returns></returns>
        byte[] serializeMessage(TMessage message);
    }
}
