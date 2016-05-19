


















// Generated on 05/16/2016 23:27:30
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class SpellForgottenMessage : AbstractMessage
{

public const uint Id = 5834;
public override uint MessageId
{
    get { return Id; }
}

public short[] spellsId;
        public short boostPoint;
        

public SpellForgottenMessage()
{
}

public SpellForgottenMessage(short[] spellsId, short boostPoint)
        {
            this.spellsId = spellsId;
            this.boostPoint = boostPoint;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteUShort((ushort)spellsId.Length);
            foreach (var entry in spellsId)
            {
                 writer.WriteShort(entry);
            }
            writer.WriteShort(boostPoint);
            

}

public override void Deserialize(IDataReader reader)
{

var limit = reader.ReadUShort();
            spellsId = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 spellsId[i] = reader.ReadShort();
            }
            boostPoint = reader.ReadShort();
            if (boostPoint < 0)
                throw new Exception("Forbidden value on boostPoint = " + boostPoint + ", it doesn't respect the following condition : boostPoint < 0");
            

}


}


}