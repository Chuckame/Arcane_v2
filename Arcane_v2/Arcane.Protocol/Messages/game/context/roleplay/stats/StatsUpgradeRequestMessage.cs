


















// Generated on 05/16/2016 23:27:30
using System;
using System.Collections.Generic;
using System.Linq;
using Arcane.Protocol.Types;
using Dofus.IO;

namespace Arcane.Protocol.Messages
{

public class StatsUpgradeRequestMessage : AbstractMessage
{

public const uint Id = 5610;
public override uint MessageId
{
    get { return Id; }
}

public sbyte statId;
        public short boostPoint;
        

public StatsUpgradeRequestMessage()
{
}

public StatsUpgradeRequestMessage(sbyte statId, short boostPoint)
        {
            this.statId = statId;
            this.boostPoint = boostPoint;
        }
        

public override void Serialize(IDataWriter writer)
{

writer.WriteSByte(statId);
            writer.WriteShort(boostPoint);
            

}

public override void Deserialize(IDataReader reader)
{

statId = reader.ReadSByte();
            if (statId < 0)
                throw new Exception("Forbidden value on statId = " + statId + ", it doesn't respect the following condition : statId < 0");
            boostPoint = reader.ReadShort();
            if (boostPoint < 0)
                throw new Exception("Forbidden value on boostPoint = " + boostPoint + ", it doesn't respect the following condition : boostPoint < 0");
            

}


}


}