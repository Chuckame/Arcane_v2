


















// Generated on 05/16/2016 23:27:24
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class CharacterCreationRequestMessage : AbstractMessage
{

public const uint Id = 160;
public override uint MessageId
{
    get { return Id; }
}

public string name;
        public sbyte breed;
        public bool sex;
        public int[] colors;
        

public CharacterCreationRequestMessage()
{
}

public CharacterCreationRequestMessage(string name, sbyte breed, bool sex, int[] colors)
        {
            this.name = name;
            this.breed = breed;
            this.sex = sex;
            this.colors = colors;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteUTF(name);
            writer.WriteSByte(breed);
            writer.WriteBoolean(sex);
            writer.WriteUShort((ushort)colors.Length);
            foreach (var entry in colors)
            {
                 writer.WriteInt(entry);
            }
            

}

public override void Deserialize(IDataReader reader)
{

name = reader.ReadUTF();
            breed = reader.ReadSByte();
            if (breed < (byte)Enums.BreedEnum.Feca || breed > (byte)Enums.BreedEnum.Zobal)
                throw new Exception("Forbidden value on breed = " + breed + ", it doesn't respect the following condition : breed < (byte)Enums.BreedEnum.Feca || breed > (byte)Enums.BreedEnum.Zobal");
            sex = reader.ReadBoolean();
            var limit = reader.ReadUShort();
            colors = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 colors[i] = reader.ReadInt();
            }
            

}


}


}