using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{
    public class IdentificationMessage : AbstractMessage
    {
        public const uint Id = 4;
        public bool autoconnect;
        public sbyte[] credentials;
        public string lang;
        public string login;
        public short serverId;
        public bool useCertificate;
        public bool useLoginToken;
        public Types.Version.Version version;

        public IdentificationMessage()
        {
        }

        public IdentificationMessage(bool autoconnect, bool useCertificate, bool useLoginToken, Types.Version.Version version, string lang, string login, sbyte[] credentials, short serverId)
        {
            this.autoconnect = autoconnect;
            this.useCertificate = useCertificate;
            this.useLoginToken = useLoginToken;
            this.version = version;
            this.lang = lang;
            this.login = login;
            this.credentials = credentials;
            this.serverId = serverId;
        }

        public override uint MessageId
        {
            get
            {
                return Id;
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            byte flag = reader.ReadByte();
            this.autoconnect = BooleanByteWrapper.GetFlag(flag, 0);
            this.useCertificate = BooleanByteWrapper.GetFlag(flag, 1);
            this.useLoginToken = BooleanByteWrapper.GetFlag(flag, 2);
            this.version = new Types.Version.Version();
            this.version.Deserialize(reader);
            this.lang = reader.ReadUTF();
            this.login = reader.ReadUTF();
            int num2 = reader.ReadUShort();
            this.credentials = new sbyte[num2];
            for (int i = 0; i < num2; i++)
            {
                this.credentials[i] = reader.ReadSByte();
            }
            this.serverId = reader.ReadShort();
        }

        public override void Serialize(IDataWriter writer)
        {
            byte flag = 0;
            flag = BooleanByteWrapper.SetFlag(BooleanByteWrapper.SetFlag(BooleanByteWrapper.SetFlag(flag, 0, this.autoconnect), 1, this.useCertificate), 2, this.useLoginToken);
            writer.WriteByte(flag);
            this.version.Serialize(writer);
            writer.WriteUTF(this.lang);
            writer.WriteUTF(this.login);
            writer.WriteUShort((ushort)this.credentials.Length);
            foreach (sbyte num2 in this.credentials)
            {
                writer.WriteSByte(num2);
            }
            writer.WriteShort(this.serverId);
        }
    }
}
