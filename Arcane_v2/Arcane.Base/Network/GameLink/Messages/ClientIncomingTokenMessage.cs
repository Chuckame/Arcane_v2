using Arcane.Base.Entities;
using Dofus.IO;
using System;
using System.Runtime.Serialization;

namespace Arcane.Base.Network.GameLink.Messages
{
    public class ClientIncomingTokenMessage : AbstractGameLinkMessage
    {
        public int AccountId { get; set; }
        public string Ticket { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(AccountId);
            writer.WriteUTF(Ticket);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            AccountId = reader.ReadInt();
            Ticket = reader.ReadUTF();
        }
    }
}