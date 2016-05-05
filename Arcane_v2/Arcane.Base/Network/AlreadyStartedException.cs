using System;

namespace Arcane.Base.Network
{
    [Serializable]
    public class AlreadyStartedException : NetworkException
    {
        public AlreadyStartedException()
        {

        }
        public AlreadyStartedException(string message) : base(message)
        {

        }
        public AlreadyStartedException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
