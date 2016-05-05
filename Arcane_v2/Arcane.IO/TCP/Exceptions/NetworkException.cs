using System;

namespace Arcane.IO.TCP.Exceptions
{
    [Serializable]
    public class NetworkException : Exception
    {
        public NetworkException()
        {

        }
        public NetworkException(string message) : base(message)
        {

        }
        public NetworkException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
