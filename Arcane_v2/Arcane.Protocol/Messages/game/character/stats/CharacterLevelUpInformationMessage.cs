


















// Generated on 05/16/2016 23:27:24
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class CharacterLevelUpInformationMessage : CharacterLevelUpMessage
{

public new const uint Id = 6076;
public override uint MessageId
{
    get { return Id; }
}

public string name;
        public int id;
        public sbyte relationType;
        

public CharacterLevelUpInformationMessage()
{
}

public CharacterLevelUpInformationMessage(byte newLevel, string name, int id, sbyte relationType)
         : base(newLevel)
        {
            this.name = name;
            this.id = id;
            this.relationType = relationType;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteUTF(name);
            writer.WriteInt(id);
            writer.WriteSByte(relationType);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            name = reader.ReadUTF();
            id = reader.ReadInt();
            if (id < 0)
                throw new Exception("Forbidden value on id = " + id + ", it doesn't respect the following condition : id < 0");
            relationType = reader.ReadSByte();
            

}


}


}