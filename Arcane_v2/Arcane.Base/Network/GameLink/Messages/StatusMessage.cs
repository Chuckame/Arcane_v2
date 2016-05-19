using Arcane.Protocol.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Base.Network.GameLink.Messages
{
    [Serializable]
    public class StatusMessage : IGameLinkMessage, ISerializable
    {
        public ServerStatusEnum Status { get; set; }

        protected StatusMessage(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException(nameof(info));

            Status = info.GetValue<ServerStatusEnum>(nameof(Status));
        }

        public StatusMessage()
        {
        }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Status), Status);
        }
    }
}
