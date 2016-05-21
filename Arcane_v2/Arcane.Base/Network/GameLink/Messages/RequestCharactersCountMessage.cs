using Arcane.Base.Network.GameLink.Messages;
using Dofus.IO;
using System;
using System.Runtime.Serialization;

namespace Arcane.Base.Network.GameLink.Messages
{
    public class RequestCharactersCountMessage : AbstractGameLinkMessage
    {
        public int AccountId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(AccountId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            AccountId = reader.ReadInt();
        }
    }
}