


















// Generated on 05/16/2016 23:27:37
using System;
using System.Collections.Generic;
using System.Linq;
using Dofus.IO;

namespace Arcane.Protocol.Types
{

public class FightLoot : AbstractType
{

public const short Id = 41;
public override short TypeId { get { return Id; } }

public short[] objects;
        public int kamas;
        

public FightLoot()
{
}

public FightLoot(short[] objects, int kamas)
        {
            this.objects = objects;
            this.kamas = kamas;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteUShort((ushort)objects.Length);
            foreach (var entry in objects)
            {
                 writer.WriteShort(entry);
            }
            writer.WriteInt(kamas);
            

}

public override void Deserialize(IDataReader reader)
{

var limit = reader.ReadUShort();
            objects = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 objects[i] = reader.ReadShort();
            }
            kamas = reader.ReadInt();
            if (kamas < 0)
                throw new Exception("Forbidden value on kamas = " + kamas + ", it doesn't respect the following condition : kamas < 0");
            

}


}


}