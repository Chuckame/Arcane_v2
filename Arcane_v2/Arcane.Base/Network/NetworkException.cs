using System;

namespace Arcane.Base.Network
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
