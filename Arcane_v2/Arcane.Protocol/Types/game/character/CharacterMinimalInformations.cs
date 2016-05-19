


















// Generated on 05/16/2016 23:27:37
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class CharacterMinimalInformations : AbstractType
{

public const short Id = 110;
public override short TypeId { get { return Id; } }

public int id;
        public byte level;
        public string name;
        

public CharacterMinimalInformations()
{
}

public CharacterMinimalInformations(int id, byte level, string name)
        {
            this.id = id;
            this.level = level;
            this.name = name;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(id);
            writer.WriteByte(level);
            writer.WriteUTF(name);
            

}

public override void Deserialize(IDataReader reader)
{

id = reader.ReadInt();
            if (id < 0)
                throw new Exception("Forbidden value on id = " + id + ", it doesn't respect the following condition : id < 0");
            level = reader.ReadByte();
            if (level < 1 || level > 200)
                throw new Exception("Forbidden value on level = " + level + ", it doesn't respect the following condition : level < 1 || level > 200");
            name = reader.ReadUTF();
            

}


}


}