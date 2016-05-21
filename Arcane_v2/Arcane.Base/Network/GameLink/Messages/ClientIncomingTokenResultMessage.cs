using Dofus.IO;
using System;
using System.Runtime.Serialization;

namespace Arcane.Base.Network.GameLink.Messages
{
    public class ClientIncomingTokenResultMessage : AbstractGameLinkMessage
    {
        public int AccountId { get; set; }
        public bool Success { get; set; }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(AccountId);
            writer.WriteBoolean(Success);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            AccountId = reader.ReadInt();
            Success = reader.ReadBoolean();
        }
    }
}