using Arcane.Base.Network.GameLink.Messages;
using Chuckame.IO.TCP.Messages;
using System;
using System.Collections.Generic;
using System.IO;
using Dofus.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using NLog;

namespace Arcane.Base.Network.GameLink
{
    public class GameLinkMessageBuilder : IMessageFactory<AbstractGameLinkMessage>
    {
        private static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();
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
            using (var writer = DofusIOUtils.CreateBigEndianWriter())
            {
                writer.WriteUTF(message.GetType().Assembly.FullName);
                writer.WriteUTF(message.GetType().FullName);
                message.Serialize(writer);
                return writer.Data;
            }
        }

        public bool TryBuildMessages(byte[] raw, out ICollection<AbstractGameLinkMessage> builtMessages)
        {
            try
            {
                builtMessages = new List<AbstractGameLinkMessage>();
                using (var reader = DofusIOUtils.CreateBigEndianReader(raw))
                {
                    var assemblyName = reader.ReadUTF();
                    var fullName = reader.ReadUTF();
                    var instance = Activator.CreateInstance(assemblyName, fullName).Unwrap();
                    if (!(instance is AbstractGameLinkMessage))
                        throw new InvalidDataException("Received message invalid.");
                    var msg = instance as AbstractGameLinkMessage;
                    msg.Deserialize(reader);
                    builtMessages.Add(msg);
                    return true;
                }
            }
            catch (Exception e)
            {
                builtMessages = null;
                LOGGER.Error(e);
                return false;
            }
        }
    }
}
