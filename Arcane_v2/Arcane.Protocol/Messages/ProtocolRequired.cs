using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{
    public class ProtocolRequired : AbstractMessage
    {
        public int currentVersion;
        public const uint Id = 1;
        public int requiredVersion;

        public ProtocolRequired()
        {
        }

        public ProtocolRequired(int requiredVersion, int currentVersion)
        {
            this.requiredVersion = requiredVersion;
            this.currentVersion = currentVersion;
        }

        public override void Deserialize(IDataReader reader)
        {
            this.requiredVersion = reader.ReadInt();
            if (this.requiredVersion < 0)
            {
                throw new Exception("Forbidden value on requiredVersion = " + this.requiredVersion + ", it doesn't respect the following condition : requiredVersion < 0");
            }
            this.currentVersion = reader.ReadInt();
            if (this.currentVersion < 0)
            {
                throw new Exception("Forbidden value on currentVersion = " + this.currentVersion + ", it doesn't respect the following condition : currentVersion < 0");
            }
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(this.requiredVersion);
            writer.WriteInt(this.currentVersion);
        }

        public override uint MessageId
        {
            get
            {
                return Id;
            }
        }
    }
}
