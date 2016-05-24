using Ionic.Zlib;

namespace Dofus.Files.Utils
{
    public class ZipHelper
    {
        public static byte[] Compress(byte[] data)
        {
            return ZlibStream.CompressBuffer(data);
        }

        public static byte[] Uncompress(byte[] data)
        {
            return ZlibStream.UncompressBuffer(data);
        }
    }
}
