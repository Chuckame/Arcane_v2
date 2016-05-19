// Generated on 05/16/2016 23:27:22
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

    public class DebugInClientMessage : AbstractMessage
    {

        public const uint Id = 6028;
        public override uint MessageId
        {
            get { return Id; }
        }

        public sbyte level;
        public string message;


        public DebugInClientMessage()
        {
        }

        public DebugInClientMessage(sbyte level, string message)
        {
            this.level = level;
            this.message = message;
        }


        public override void Serialize(IDataWriter writer)
        {

            writer.WriteSByte(level);
            writer.WriteUTF(message);


        }

        public override void Deserialize(IDataReader reader)
        {

            level = reader.ReadSByte();
            if (level < 0)
                throw new Exception("Forbidden value on level = " + level + ", it doesn't respect the following condition : level < 0");
            message = reader.ReadUTF();


        }


    }


}