﻿using Arcane.Protocol.Enums;
using Dofus.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Arcane.Base.Network.GameLink.Messages
{
    public class HelloMessage : StatusMessage
    {
        public ushort ServerId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUShort(ServerId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            ServerId = reader.ReadUShort();
        }
    }
}
