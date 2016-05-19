using Arcane.Base.Network.GameLink.Messages;
using Chuckame.IO.TCP.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Base.Network.GameLink
{
    public class GameLinkMessageBuilder : IMessageFactory<IGameLinkMessage>
    {
        #region Singleton
        private static GameLinkMessageBuilder _instance = new GameLinkMessageBuilder();

        public static GameLinkMessageBuilder Instance
        {
            get
            {
                return _instance;
            }
        }
        
        private GameLinkMessageBuilder()
        {
        }
        #endregion

        public byte[] SerializeMessage(IGameLinkMessage message)
        {
            throw new NotImplementedException();
        }

        public bool TryBuildMessages(byte[] raw, out ICollection<IGameLinkMessage> builtMessages)
        {
            throw new NotImplementedException();
        }
    }
}
