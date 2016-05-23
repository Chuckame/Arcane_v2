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
    public class TestResponseMessage : AbstractGameLinkMessage
    {
        public string TestStr { get; set; }
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(TestStr);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            TestStr = reader.ReadUTF();
        }
    }
}
