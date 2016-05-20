using Arcane.Base.Network.GameLink.Messages;
using Chuckame.IO.TCP.Messages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Base.Network.GameLink
{
    public class GameLinkMessageBuilder : IMessageFactory<AbstractGameLinkMessage>
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

        public byte[] SerializeMessage(AbstractGameLinkMessage message)
        {
            var formatter = new BinaryFormatter();
            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, message);
                return stream.GetBuffer();
            }
        }

        public bool TryBuildMessages(byte[] raw, out ICollection<AbstractGameLinkMessage> builtMessages)
        {
            try
            {
                builtMessages = new List<AbstractGameLinkMessage>();
                var formatter = new BinaryFormatter();
                using (var stream = new MemoryStream(raw))
                {
                    builtMessages.Add((AbstractGameLinkMessage)formatter.Deserialize(stream));
                    return true;
                }
            }
            catch (Exception)
            {
                builtMessages = null;
                return false;
            }
        }
    }
}
