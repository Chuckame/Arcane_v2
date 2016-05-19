


















// Generated on 05/16/2016 23:27:21
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class ConsoleCommandsListMessage : AbstractMessage
{

public const uint Id = 6127;
public override uint MessageId
{
    get { return Id; }
}

public string[] aliases;
        public string[] arguments;
        public string[] descriptions;
        

public ConsoleCommandsListMessage()
{
}

public ConsoleCommandsListMessage(string[] aliases, string[] arguments, string[] descriptions)
        {
            this.aliases = aliases;
            this.arguments = arguments;
            this.descriptions = descriptions;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteUShort((ushort)aliases.Length);
            foreach (var entry in aliases)
            {
                 writer.WriteUTF(entry);
            }
            writer.WriteUShort((ushort)arguments.Length);
            foreach (var entry in arguments)
            {
                 writer.WriteUTF(entry);
            }
            writer.WriteUShort((ushort)descriptions.Length);
            foreach (var entry in descriptions)
            {
                 writer.WriteUTF(entry);
            }
            

}

public override void Deserialize(IDataReader reader)
{

var limit = reader.ReadUShort();
            aliases = new string[limit];
            for (int i = 0; i < limit; i++)
            {
                 aliases[i] = reader.ReadUTF();
            }
            limit = reader.ReadUShort();
            arguments = new string[limit];
            for (int i = 0; i < limit; i++)
            {
                 arguments[i] = reader.ReadUTF();
            }
            limit = reader.ReadUShort();
            descriptions = new string[limit];
            for (int i = 0; i < limit; i++)
            {
                 descriptions[i] = reader.ReadUTF();
            }
            

}


}


}