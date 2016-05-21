using Arcane.Base.Network.GameLink.Messages;
using System;
using System.Runtime.Serialization;
using Dofus.IO;

namespace Arcane.Base.Network.GameLink.Messages
{
    public class CharactersCountMessage : AbstractGameLinkMessage
    {
        public int AccountId { get; set; }
        public sbyte CharactersCount { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(AccountId);
            writer.WriteSByte(CharactersCount);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            AccountId = reader.ReadInt();
            CharactersCount = reader.ReadSByte();
        }
    }
}