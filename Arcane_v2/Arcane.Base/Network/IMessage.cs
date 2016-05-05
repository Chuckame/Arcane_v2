using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Base.Network
{
    /// <summary>
    /// Représente un message.
    /// </summary>
    public interface IMessage
    {
        /// <summary>
        /// Sérialise en un tableau d'octets l'instance de <see cref="IMessage"/> actuelle.
        /// </summary>
        /// <returns></returns>
        byte[] Serialize();

        /// <summary>
        /// Rempli l'instance de <see cref="IMessage"/> actuelle en désérialisant des données brutes.
        /// </summary>
        /// <param name="raw"></param>
        void Deserialize(byte[] raw);
    }
}
