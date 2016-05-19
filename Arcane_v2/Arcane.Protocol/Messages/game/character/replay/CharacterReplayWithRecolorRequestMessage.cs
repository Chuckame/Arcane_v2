


















// Generated on 05/16/2016 23:27:24
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class CharacterReplayWithRecolorRequestMessage : CharacterReplayRequestMessage
{

public new const uint Id = 6111;
public override uint MessageId
{
    get { return Id; }
}

public int[] indexedColor;
        

public CharacterReplayWithRecolorRequestMessage()
{
}

public CharacterReplayWithRecolorRequestMessage(int characterId, int[] indexedColor)
         : base(characterId)
        {
            this.indexedColor = indexedColor;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteUShort((ushort)indexedColor.Length);
            foreach (var entry in indexedColor)
            {
                 writer.WriteInt(entry);
            }
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            var limit = reader.ReadUShort();
            indexedColor = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 indexedColor[i] = reader.ReadInt();
            }
            

}


}


}