using System;

namespace Dofus.Files.Exceptions
{
    [Serializable]
    public class ConfigException : Exception
    {
        public ConfigException()
        {

        }
        public ConfigException(string message) : base(message)
        {

        }
        public ConfigException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
