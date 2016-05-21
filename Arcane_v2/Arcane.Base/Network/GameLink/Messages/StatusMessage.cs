using Arcane.Protocol.Enums;
using Dofus.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Base.Network.GameLink.Messages
{
    public class StatusMessage : AbstractGameLinkMessage
    {
        public ServerStatusEnum Status { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte((sbyte)Status);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Status = (ServerStatusEnum)reader.ReadSByte();
        }
    }
}
