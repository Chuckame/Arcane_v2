using Chuckame.IO.TCP.Messages;
using Dofus.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Protocol.Messages
{
    public class MessageBuilder : IMessageFactory<AbstractMessage>
    {
        private static readonly MessageBuilder _instance = new MessageBuilder();
        private readonly Dictionary<uint, Func<AbstractMessage>> _messagesConstructor = new Dictionary<uint, Func<AbstractMessage>>();
        private readonly Dictionary<uint, Type> _messagesType = new Dictionary<uint, Type>();

        public static MessageBuilder Instance
        {
            get
            {
                return _instance;
            }
        }
        private MessageBuilder()
        {

        }

        public void Initialize(Assembly assembly)
        {
            foreach (Type type in assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(AbstractMessage))))
            {
                var ctor = type.GetConstructor(Type.EmptyTypes);

                if (ctor == null)
                    throw new Exception($"'{type}' doesn't implemented a parameterless constructor");

                Func<AbstractMessage> ctorDel = () => (AbstractMessage)ctor.Invoke(new object[0]);

                var id = ctorDel().MessageId;
                if (_messagesType.ContainsKey(id))
                    throw new AmbiguousMatchException($"The message with id '{id}' is already in the dictionary, old type is : {_messagesType[id]}, new type is  {type}");

                _messagesType.Add(id, type);
                _messagesConstructor.Add(id, ctorDel);
            }
        }

        public Type GetMessageType(uint id)
        {
            if (!_messagesType.ContainsKey(id))
                throw new IndexOutOfRangeException($"There's no message with id={id}.");
            return _messagesType[id];
        }

        public AbstractMessage CreateMessageInstance(uint id)
        {
            if (!_messagesConstructor.ContainsKey(id))
                throw new IndexOutOfRangeException($"There's no message with id={id}.");
            return _messagesConstructor[id]();
        }

        public IEnumerable<AbstractMessage> buildMessages(byte[] raw)
        {
            var list = new List<AbstractMessage>();
            var r = DofusIOUtils.CreateBigEndianReader(raw);
            while (r.BytesAvailable >= 2)
            {
                var header = r.ReadUShort();
                var messageId = (uint)(header >> 2);
                var typeLen = header & 3;
                if (r.BytesAvailable >= typeLen)
                {
                    var length = readMessageLength(typeLen, r);
                    if (r.BytesAvailable >= length)
                    {
                        var msg = CreateMessageInstance(messageId);
                        msg.Deserialize(r);
                        list.Add(msg);
                    }
                }
            }
            return list;
        }

        public byte[] serializeMessage(AbstractMessage message)
        {
            using (var contentWriter = DofusIOUtils.CreateBigEndianWriter())
            using (var finalWriter = DofusIOUtils.CreateBigEndianWriter())
            {
                try
                {
                    message.Serialize(contentWriter);
                }
                catch (Exception e)
                {
                    throw new MalformatedMessageException(e.ToString(), e);
                }

                var typeLen = computeTypeLen((int)contentWriter.Length);
                finalWriter.WriteShort(subComputeStaticHeader(message.MessageId, typeLen));
                switch (typeLen)
                {
                    case 0:
                        break;

                    case 1:
                        finalWriter.WriteSByte((sbyte)contentWriter.Length);
                        break;

                    case 2:
                        finalWriter.WriteShort((short)contentWriter.Length);
                        break;

                    case 3:
                        finalWriter.WriteSByte((sbyte)((contentWriter.Length >> 16) & 255));
                        finalWriter.WriteShort((short)(contentWriter.Length & 65535));
                        break;

                    default:
                        throw new Exception("Packet length can't be encoded on 4 or more bytes");
                }
                finalWriter.WriteBytes(contentWriter.Data);
                return finalWriter.Data;
            }
        }

        [Serializable]
        public class MalformatedMessageException : Exception
        {
            public MalformatedMessageException() { }
            public MalformatedMessageException(string message) : base(message) { }
            public MalformatedMessageException(string message, Exception inner) : base(message, inner) { }
            public MalformatedMessageException(Exception inner) : base("", inner) { }
        }
        private static int readMessageLength(int typeLen, IDataReader reader)
        {
            var length = 0;
            switch (typeLen)
            {
                case 0:
                    break;
                case 1:
                    length = reader.ReadByte();
                    break;

                case 2:
                    length = reader.ReadUShort();
                    break;

                case 3:
                    length = ((reader.ReadSByte() & 255) << 16) + ((reader.ReadByte() & 255) << 8) + (reader.ReadByte() & 255);
                    break;

                default:
                    throw new NotSupportedException();
            }
            return length;
        }
        private short subComputeStaticHeader(uint id, byte typeLen)
        {
            return (short)((id << 2) | typeLen);
        }

        private byte computeTypeLen(int len)
        {
            if (len > 65535)
            {
                return 3;
            }
            if (len > 255)
            {
                return 2;
            }
            if (len > 0)
            {
                return 1;
            }
            return 0;
        }

    }
}
