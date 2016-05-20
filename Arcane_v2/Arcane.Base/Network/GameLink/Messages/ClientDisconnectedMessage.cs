using Arcane.Base.Network.GameLink.Messages;
using System;
using System.Runtime.Serialization;

namespace Arcane.Base.Network.GameLink.Messages
{
    [Serializable]
    public class ClientDisconnectedMessage : AbstractGameLinkMessage
    {
        public int AccountId { get; set; }
        
        protected ClientDisconnectedMessage(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            if (info == null)
                throw new ArgumentNullException(nameof(info));

            AccountId = info.GetValue<int>(nameof(AccountId));
        }

        public ClientDisconnectedMessage()
        {
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue(nameof(AccountId), AccountId);
        }
    }
}