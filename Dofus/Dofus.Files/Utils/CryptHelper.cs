using System;

namespace Dofus.Files.Utils
{
    public static class CryptHelper
    {
        public static byte[] DecryptXor(byte[] inputBytes, byte[] decryptionKey)
        {
            if (inputBytes == null)
                throw new ArgumentNullException(nameof(inputBytes));
            if (decryptionKey == null)
                throw new ArgumentNullException(nameof(decryptionKey));
            byte[] bytes = new byte[inputBytes.Length];
            inputBytes.CopyTo(bytes, 0);
            for (uint ind = 0; ind < bytes.Length; ++ind)
            {
                bytes[ind] ^= decryptionKey[ind % decryptionKey.Length];
            }
            return bytes;
        }
        public static byte[] EncryptXor(byte[] inputBytes, byte[] decryptionKey)
        {
            return DecryptXor(inputBytes, decryptionKey);
        }
    }
}
