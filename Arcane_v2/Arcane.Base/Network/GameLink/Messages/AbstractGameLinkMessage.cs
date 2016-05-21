using Chuckame.IO.TCP.Messages;
using Dofus.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Base.Network.GameLink.Messages
{
    public abstract class AbstractGameLinkMessage : IMessage
    {
        public Guid? Token { get; set; }

        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Token.HasValue);
            if (Token.HasValue)
            {
                var bytes = Token.Value.ToByteArray();
                writer.WriteUShort((ushort)bytes.Length);
                writer.WriteBytes(bytes);
            }
        }

        public virtual void Deserialize(IDataReader reader)
        {
            var hasToken = reader.ReadBoolean();
            if (hasToken)
            {
                var bytes = reader.ReadBytes(reader.ReadUShort());
                Token = new Guid(bytes);
            }
        }
    }
}
