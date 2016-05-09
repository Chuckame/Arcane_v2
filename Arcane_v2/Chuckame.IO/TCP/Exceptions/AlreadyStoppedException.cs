using System;

namespace Chuckame.IO.TCP.Exceptions
{
    [Serializable]
    public class AlreadyStoppedException : NetworkException
    {
        public AlreadyStoppedException()
        {

        }
        public AlreadyStoppedException(string message) : base(message)
        {

        }
        public AlreadyStoppedException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
