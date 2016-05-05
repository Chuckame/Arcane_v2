using System;

namespace Arcane.IO.TCP.Exceptions
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
