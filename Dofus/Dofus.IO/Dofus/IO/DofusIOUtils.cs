using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dofus.IO
{
    public static class DofusIOUtils
    {
        public static IDataReader CreateBigEndianReader()
        {
            return new BigEndianReader();
        }
        public static IDataReader CreateBigEndianReader(Stream stream)
        {
            return new BigEndianReader(stream);
        }
        public static IDataReader CreateBigEndianReader(byte[] bytes)
        {
            return new BigEndianReader(bytes);
        }
        public static IDataReader CreateFastBigEndianReader(Stream stream)
        {
            var buffer = new byte[stream.Length - stream.Position];
            stream.Read(buffer, 0, buffer.Length);
            return new FastBigEndianReader(buffer);
        }
        public static IDataReader CreateFastBigEndianReader(byte[] bytes)
        {
            return new FastBigEndianReader(bytes);
        }
        public static IDataWriter CreateBigEndianWriter()
        {
            return new BigEndianWriter();
        }
        public static IDataWriter CreateBigEndianWriter(Stream stream)
        {
            return new BigEndianWriter(stream);
        }
        public static IDataWriter CreateBigEndianWriter(byte[] bytes)
        {
            return new BigEndianWriter(bytes);
        }
    }
}
