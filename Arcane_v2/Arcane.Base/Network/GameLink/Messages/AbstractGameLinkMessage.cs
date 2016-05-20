using Chuckame.IO.TCP.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Base.Network.GameLink.Messages
{
    public abstract class AbstractGameLinkMessage : IMessage
    {
        public Guid Token { get; set; }
        public bool HasToken()
        {
            return Token != null;
        }
        protected AbstractGameLinkMessage(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException(nameof(info));

            var hasToken = info.GetValue<bool>(nameof(HasToken));
            if (hasToken)
                Token = info.GetValue<Guid>(nameof(Token));
        }

        public AbstractGameLinkMessage()
        {
        }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(HasToken), HasToken());
            if (HasToken())
                info.AddValue(nameof(Token), Token);
        }
    }
}
