using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Base.Encryption
{
    public class RSAProtocol
    {
        private static RSACryptoServiceProvider m_RSAProvider;
        public static sbyte[] PublicKey;

        public static void GenerateKey()
        {
            var csp = new CspParameters
            {
                ProviderType = 1,
                KeyNumber = 1
            };
            m_RSAProvider = new RSACryptoServiceProvider(2048, csp)
            {
                PersistKeyInCsp = false
            };

            PublicKey = Array.ConvertAll<byte, sbyte>(AsnKeyBuilder.PublicKeyToX509(m_RSAProvider.ExportParameters(false)).GetBytes(), (a) => (sbyte)a);
        }

        public static string DecryptCredentials(sbyte[] credentials)
        {
            return Encoding.Default.GetString(m_RSAProvider.Decrypt(Array.ConvertAll<sbyte, byte>(credentials, (a) => (byte)a), false)).Substring(32);
        }
    }
}
