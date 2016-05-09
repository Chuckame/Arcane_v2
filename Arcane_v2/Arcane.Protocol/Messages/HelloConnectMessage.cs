using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{
    public class HelloConnectMessage : AbstractMessage
    {
        public const uint Id = 3;
        public override uint MessageId
        {
            get
            {
                return Id;
            }
        }
        public sbyte[] key;
        public string salt;

        public HelloConnectMessage()
        {
        }

        public HelloConnectMessage(string salt, sbyte[] key)
        {
            this.salt = salt;
            this.key = key;
        }

        public override void Deserialize(IDataReader reader)
        {
            this.salt = reader.ReadUTF();
            int num = reader.ReadUShort();
            this.key = new sbyte[num];
            for (int i = 0; i < num; i++)
            {
                this.key[i] = reader.ReadSByte();
            }
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(this.salt);
            writer.WriteUShort((ushort)this.key.Length);
            foreach (sbyte num in this.key)
            {
                writer.WriteSByte(num);
            }
        }
    }
}
