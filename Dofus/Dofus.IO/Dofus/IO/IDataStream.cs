using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dofus.IO
{
    public interface IDataStream : IDisposable
    {
        /// <summary>
        /// Get all bytes of this stream.
        /// </summary>
        byte[] Data
        {
            get;
        }

        /// <summary>
        /// Get the length of this stream.
        /// </summary>
        long Length
        {
            get;
        }

        /// <summary>
        /// Get the position of this stream.
        /// </summary>
        long Position
        {
            get;
        }

        /// <summary>
        /// Set the position of this stream.
        /// </summary>
        void SetPosition(long newPosition);

        /// <summary>
        /// Clone this stream.
        /// </summary>
        /// <returns></returns>
        IDataStream Clone();
    }
}
