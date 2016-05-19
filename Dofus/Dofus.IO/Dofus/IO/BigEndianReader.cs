using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Dofus.IO
{
    internal class BigEndianReader : IDataReader, IDisposable
    {
        #region Properties

        private BinaryReader m_reader;

        /// <summary>
        ///   Gets availiable bytes number in the buffer
        /// </summary>
        public long BytesAvailable
        {
            get { return m_reader.BaseStream.Length - m_reader.BaseStream.Position; }
        }

        public long Position
        {
            get
            {
                return m_reader.BaseStream.Position;
            }
        }


        public Stream BaseStream
        {
            get
            {
                return m_reader.BaseStream;
            }
        }

        #endregion

        #region Initialisation

        /// <summary>
        ///   Initializes a new instance of the <see cref = "BigEndianReader" /> class.
        /// </summary>
        internal BigEndianReader()
        {
            m_reader = new BinaryReader(new MemoryStream(), Encoding.UTF8);
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref = "BigEndianReader" /> class.
        /// </summary>
        /// <param name = "stream">The stream.</param>
        internal BigEndianReader(Stream stream)
        {
            m_reader = new BinaryReader(stream, Encoding.UTF8);
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref = "BigEndianReader" /> class.
        /// </summary>
        /// <param name = "tab">Memory buffer.</param>
        internal BigEndianReader(byte[] tab)
        {
            m_reader = new BinaryReader(new MemoryStream(tab), Encoding.UTF8);
        }

        #endregion

        #region Private Methods

        /// <summary>
        ///   Read bytes in big endian format
        /// </summary>
        /// <param name = "count"></param>
        /// <returns></returns>
        private byte[] ReadBigEndianBytes(int count)
        {
            var bytes = new byte[count];
            int i;
            for (i = count - 1; i >= 0; i--)
                bytes[i] = (byte)BaseStream.ReadByte();
            return bytes;
        }

        #endregion

        #region Public Method

        /// <summary>
        ///   Read a Short from the Buffer
        /// </summary>
        /// <returns></returns>
        public short ReadShort()
        {
            return BitConverter.ToInt16(ReadBigEndianBytes(2), 0);
        }

        /// <summary>
        ///   Read a int from the Buffer
        /// </summary>
        /// <returns></returns>
        public int ReadInt()
        {
            return BitConverter.ToInt32(ReadBigEndianBytes(4), 0);
        }

        /// <summary>
        ///   Read a long from the Buffer
        /// </summary>
        /// <returns></returns>
        public Int64 ReadLong()
        {
            return BitConverter.ToInt64(ReadBigEndianBytes(8), 0);
        }

        /// <summary>
        ///   Read a Float from the Buffer
        /// </summary>
        /// <returns></returns>
        public float ReadFloat()
        {
            return BitConverter.ToSingle(ReadBigEndianBytes(4), 0);
        }

        /// <summary>
        ///   Read a UShort from the Buffer
        /// </summary>
        /// <returns></returns>
        public ushort ReadUShort()
        {
            return BitConverter.ToUInt16(ReadBigEndianBytes(2), 0);
        }

        /// <summary>
        ///   Read a int from the Buffer
        /// </summary>
        /// <returns></returns>
        public UInt32 ReadUInt()
        {
            return BitConverter.ToUInt32(ReadBigEndianBytes(4), 0);
        }

        /// <summary>
        ///   Read a long from the Buffer
        /// </summary>
        /// <returns></returns>
        public UInt64 ReadULong()
        {
            return BitConverter.ToUInt64(ReadBigEndianBytes(8), 0);
        }

        /// <summary>
        ///   Read a byte from the Buffer
        /// </summary>
        /// <returns></returns>
        public byte ReadByte()
        {
            return m_reader.ReadByte();
        }

        public sbyte ReadSByte()
        {
            return m_reader.ReadSByte();
        }

        public byte[] Data
        {
            get
            {
                var pos = BaseStream.Position;

                var data = new byte[BaseStream.Length];
                BaseStream.Position = 0;
                BaseStream.Read(data, 0, (int)BaseStream.Length);

                BaseStream.Position = pos;

                return data;
            }
        }

        public long Length
        {
            get
            {
                return BaseStream.Length;
            }
        }

        /// <summary>
        ///   Returns N bytes from the buffer
        /// </summary>
        /// <param name = "n">Number of read bytes.</param>
        /// <returns></returns>
        public byte[] ReadBytes(int n)
        {
            return m_reader.ReadBytes(n);
        }

        /// <summary>
        /// Returns N bytes from the buffer
        /// </summary>
        /// <param name = "n">Number of read bytes.</param>
        /// <returns></returns>
        public BigEndianReader ReadBytesInNewBigEndianReader(int n)
        {
            return new BigEndianReader(m_reader.ReadBytes(n));
        }

        /// <summary>
        ///   Read a Boolean from the Buffer
        /// </summary>
        /// <returns></returns>
        public Boolean ReadBoolean()
        {
            return m_reader.ReadByte() == 1;
        }

        /// <summary>
        ///   Read a Char from the Buffer
        /// </summary>
        /// <returns></returns>
        public Char ReadChar()
        {
            return (char)ReadUShort();
        }

        /// <summary>
        ///   Read a Double from the Buffer
        /// </summary>
        /// <returns></returns>
        public Double ReadDouble()
        {
            return BitConverter.ToDouble(ReadBigEndianBytes(8), 0);
        }

        /// <summary>
        ///   Read a Single from the Buffer
        /// </summary>
        /// <returns></returns>
        public Single ReadSingle()
        {
            return BitConverter.ToSingle(ReadBigEndianBytes(4), 0);
        }

        /// <summary>
        ///   Read a string from the Buffer
        /// </summary>
        /// <returns></returns>
        public string ReadUTF()
        {
            var length = ReadUShort();

            var bytes = ReadBytes(length);
            return Encoding.UTF8.GetString(bytes);
        }

        /// <summary>
        ///   Read a string from the Buffer
        /// </summary>
        /// <returns></returns>
        public string ReadUTF7BitLength()
        {
            var length = ReadInt();

            var bytes = ReadBytes(length);
            return Encoding.UTF8.GetString(bytes);
        }

        public string ReadUTFBytes(ushort len)
        {
            var bytes = ReadBytes(len);

            return Encoding.UTF8.GetString(bytes);
        }

        /// <summary>
        ///   Skip bytes
        /// </summary>
        /// <param name = "n"></param>
        public void SkipBytes(int n)
        {
            int i;
            for (i = 0; i < n; i++)
            {
                m_reader.ReadByte();
            }
        }

        public void SetPosition(long Position)
        {
            Seek(Position, SeekOrigin.Begin);
        }

        public void Seek(long offset, SeekOrigin seekOrigin)
        {
            m_reader.BaseStream.Seek(offset, seekOrigin);
        }

        /// <summary>
        ///   Add a bytes array to the end of the buffer
        /// </summary>
        /// <param name="data">todo: describe data parameter on Add</param>
        /// <param name="offset">todo: describe offset parameter on Add</param>
        /// <param name="count">todo: describe count parameter on Add</param>
        public void Add(byte[] data, int offset, int count)
        {
            var pos = m_reader.BaseStream.Position;

            m_reader.BaseStream.Position = m_reader.BaseStream.Length;
            m_reader.BaseStream.Write(data, offset, count);
            m_reader.BaseStream.Position = pos;
        }

        public void Close()
        {
            BaseStream.Close();
        }

        #endregion

        #region Alternatives Methods
        public short ReadInt16()
        {
            return ReadShort();
        }

        public int ReadInt32()
        {
            return ReadInt();
        }

        public long ReadInt64()
        {
            return ReadLong();
        }

        public ushort ReadUInt16()
        {
            return ReadUShort();
        }

        public uint ReadUInt32()
        {
            return ReadUInt();
        }

        public ulong ReadUInt64()
        {
            return ReadULong();
        }

        public string ReadString()
        {
            return ReadUTF();
        }
        #endregion

        #region Custom Methods

        private const int INT_SIZE = 32;
        private const int SHORT_SIZE = 16;
        private const int SHORT_MIN_VALUE = -32768;
        private const int SHORT_MAX_VALUE = 32767;
        private const int UNSIGNED_SHORT_MAX_VALUE = 65536;
        private const int CHUNCK_BIT_SIZE = 7;

        private const int MASK_1 = 128;
        private const int MASK_0 = 127;


        public int ReadVarInt()
        {
            var local_4 = 0;
            var local_1 = 0;
            var local_2 = 0;
            var local_3 = false;

            while (local_2 < INT_SIZE)
            {
                local_4 = ReadByte();
                local_3 = (local_4 & MASK_1) == MASK_1;

                if (local_2 > 0)
                {
                    local_1 += ((local_4 & MASK_0) << local_2);
                }
                else
                {
                    local_1 += (local_4 & MASK_0);
                }

                local_2 += CHUNCK_BIT_SIZE;

                if (!local_3)
                {
                    return local_1;
                }
            }

            throw new System.Exception("Too much data");
        }

        public uint ReadVarUhInt()
        {
            return (uint)(ReadVarInt());
        }

        public int ReadVarShort()
        {
            var local_4 = 0;
            var local_1 = 0;
            var local_2 = 0;
            var local_3 = false;

            while (local_2 < SHORT_SIZE)
            {
                local_4 = ReadByte();
                local_3 = (local_4 & MASK_1) == MASK_1;

                if (local_2 > 0)
                {
                    local_1 += ((local_4 & MASK_0) << local_2);
                }
                else
                {
                    local_1 += (local_4 & MASK_0);
                }

                local_2 += CHUNCK_BIT_SIZE;

                if (!local_3)
                {
                    if (local_1 > SHORT_MAX_VALUE)
                    {
                        local_1 -= UNSIGNED_SHORT_MAX_VALUE;
                    }
                    return local_1;
                }
            }

            throw new System.Exception("Too much data");
        }

        public uint ReadVarUhShort()
        {
            return (uint)(ReadVarShort());
        }

        public double ReadVarLong()
        {
            return ReadVarInt64().ToNumber();
        }

        public double ReadVarUhLong()
        {
            return ReadVarUInt64().ToNumber();
        }

        public FinalInt64 ReadVarInt64()
        {
            var local_3 = 0;
            var local_2 = new FinalInt64();
            var local_4 = 0;

            while (true)
            {
                local_3 = ReadByte();
                if (local_4 == 28)
                {
                    break;
                }
                if (local_3 >= 128)
                {
                    local_2.Low = local_2.Low | (uint)((local_3 & 127) << local_4);
                    local_4 += 7;
                    continue;
                }
                local_2.Low = local_2.Low | (uint)(local_3 << local_4);
                return local_2;
            }

            if (local_3 >= 128)
            {
                local_3 = local_3 & 127;
                local_2.Low = local_2.Low | (uint)(local_3 << local_4);
                local_2.High = (uint)(local_3 >> 4);
                local_4 = 3;

                while (true)
                {
                    local_3 = ReadByte();
                    if (local_4 < 32)
                    {
                        if (local_3 >= 128)
                        {
                            local_2.High = local_2.High | (uint)((local_3 & 127) << local_4);
                        }
                        else
                        {
                            break;
                        }
                    }
                    local_4 += 7;
                }
                local_2.High = local_2.High | (uint)(local_3 << local_4);
                return local_2;
            }
            local_2.Low = local_2.Low | (uint)(local_3 << local_4);
            local_2.High = (uint)(local_3 >> 4);
            return local_2;
        }

        public FinalUInt64 ReadVarUInt64()
        {
            var local_2 = new FinalUInt64();
            var local_3 = 0;
            var local_4 = 0;

            while (true)
            {
                local_3 = ReadByte();
                if (local_4 == 28)
                {
                    break;
                }
                if (local_3 >= 128)
                {
                    local_2.Low = local_2.Low | (uint)((local_3 & 127) << local_4);
                    local_4 += 7;
                    continue;
                }
                local_2.Low = local_2.Low | (uint)(local_3 << local_4);
                return local_2;
            }

            if (local_3 >= 128)
            {
                local_3 = local_3 & 127;
                local_2.Low = local_2.Low | (uint)(local_3 << local_4);
                local_2.High = (uint)(local_3 >> 4);
                local_4 = 3;

                while (true)
                {
                    local_3 = ReadByte();
                    if (local_4 < 32)
                    {
                        if (local_3 >= 128)
                        {
                            local_2.High = local_2.High | (uint)((local_3 & 127) << local_4);
                        }
                        else
                        {
                            break;
                        }
                    }
                    local_4 += 7;
                }
                local_2.High = local_2.High | (uint)(local_3 << local_4);
                return local_2;
            }
            local_2.Low = local_2.Low | (uint)(local_3 << local_4);
            local_2.High = (uint)(local_3 >> 4);
            return local_2;
        }

        #endregion

        #region Dispose

        /// <summary>
        ///   Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            m_reader.Dispose();
            m_reader = null;
            GC.SuppressFinalize(this);
        }

        public IDataStream Clone()
        {
            var mStream = new MemoryStream();
            BaseStream.CopyTo(mStream);
            return new BigEndianReader(mStream);
        }

        #endregion
    }
}
