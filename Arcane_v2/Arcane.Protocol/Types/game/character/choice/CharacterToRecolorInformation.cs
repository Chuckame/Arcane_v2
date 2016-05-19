


















// Generated on 05/16/2016 23:27:37
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class CharacterToRecolorInformation : AbstractType
{

public const short Id = 212;
public override short TypeId { get { return Id; } }

public int id;
        public int[] colors;
        

public CharacterToRecolorInformation()
{
}

public CharacterToRecolorInformation(int id, int[] colors)
        {
            this.id = id;
            this.colors = colors;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteInt(id);
            writer.WriteUShort((ushort)colors.Length);
            foreach (var entry in colors)
            {
                 writer.WriteInt(entry);
            }
            

}

public override void Deserialize(IDataReader reader)
{

id = reader.ReadInt();
            if (id < 0)
                throw new Exception("Forbidden value on id = " + id + ", it doesn't respect the following condition : id < 0");
            var limit = reader.ReadUShort();
            colors = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 colors[i] = reader.ReadInt();
            }
            

}


}


}