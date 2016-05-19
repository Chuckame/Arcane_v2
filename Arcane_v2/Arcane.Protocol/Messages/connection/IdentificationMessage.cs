


















// Generated on 05/16/2016 23:27:21
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class IdentificationMessage : AbstractMessage
{

public const uint Id = 4;
public override uint MessageId
{
    get { return Id; }
}

public bool autoconnect;
        public bool useCertificate;
        public bool useLoginToken;
        public Types.Version version;
        public string lang;
        public string login;
        public sbyte[] credentials;
        public short serverId;
        

public IdentificationMessage()
{
}

public IdentificationMessage(bool autoconnect, bool useCertificate, bool useLoginToken, Types.Version version, string lang, string login, sbyte[] credentials, short serverId)
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
        

public override void Serialize(IDataWriter writer)
{

byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, autoconnect);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, useCertificate);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 2, useLoginToken);
            writer.WriteByte(flag1);
            version.Serialize(writer);
            writer.WriteUTF(lang);
            writer.WriteUTF(login);
            writer.WriteUShort((ushort)credentials.Length);
            foreach (var entry in credentials)
            {
                 writer.WriteSByte(entry);
            }
            writer.WriteShort(serverId);
            

}

public override void Deserialize(IDataReader reader)
{

byte flag1 = reader.ReadByte();
            autoconnect = BooleanByteWrapper.GetFlag(flag1, 0);
            useCertificate = BooleanByteWrapper.GetFlag(flag1, 1);
            useLoginToken = BooleanByteWrapper.GetFlag(flag1, 2);
            version = new Types.Version();
            version.Deserialize(reader);
            lang = reader.ReadUTF();
            login = reader.ReadUTF();
            var limit = reader.ReadUShort();
            credentials = new sbyte[limit];
            for (int i = 0; i < limit; i++)
            {
                 credentials[i] = reader.ReadSByte();
            }
            serverId = reader.ReadShort();
            

}


}


}