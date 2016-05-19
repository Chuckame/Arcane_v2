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
    public class HelloMessage : StatusMessage, IGameLinkMessage, ISerializable
    {
        public ushort ServerId { get; set; }
        protected HelloMessage(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            if (info == null)
                throw new ArgumentNullException(nameof(info));

            ServerId = info.GetValue<ushort>(nameof(ServerId));
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue(nameof(ServerId), ServerId);
        }
    }
}
