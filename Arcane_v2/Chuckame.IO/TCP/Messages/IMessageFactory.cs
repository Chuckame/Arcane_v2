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
        /// Extrait un ou plusieurs messages(s) depuis un buffer. Retourne true si un ou plusieurs message(s) peuvent être lu(s), sinon false.
        /// </summary>
        /// <param name="raw">Buffer.</param>
        /// <param name="builtMessages">Paramètre de sortie contenant les messages s'ils ont pu être extraits.</param>
        /// <returns>true si un ou plusieurs message(s) peuvent être lu(s), sinon false.</returns>
        bool TryBuildMessages(byte[] raw, out ICollection<TMessage> builtMessages);

        /// <summary>
        /// Sérialise un message en un tableau d'octet.
        /// </summary>
        /// <param name="message">Message à sérialiser.</param>
        /// <returns></returns>
        byte[] SerializeMessage(TMessage message);
    }
}
